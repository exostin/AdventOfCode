namespace AdventOfCode.Solutions.Year2021.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2021, "") { }

    protected override string SolvePartOne()
    {
        string[] depthReadings = Input.SplitByNewline();
        int[] depthMeasurements = new int[depthReadings.Length];
            
        ConvertReadingsToIntMeasurements(depthReadings, depthMeasurements);

        int cachedDepth = depthMeasurements[0];
            
        int depthIncreasedCount = 0;

        int iterationsCount = depthReadings.Length;
            
        for (int i = 1; i < iterationsCount; i++)
        {
            int currentDepth = depthMeasurements[i];
            if (currentDepth > cachedDepth) depthIncreasedCount++;
            cachedDepth = currentDepth;
        }
        return depthIncreasedCount.ToString();
    }

    protected override string SolvePartTwo()
    {
        string[] depthReadings = Input.SplitByNewline();
        int[] depthMeasurements = new int[depthReadings.Length];
            
        ConvertReadingsToIntMeasurements(depthReadings, depthMeasurements);

        int cachedDepthSum =
            new MeasurementWindow(depthMeasurements[0], depthMeasurements[1], depthMeasurements[2])
                .MeasurementSum();
            
        int depthIncreasedCount = 0;
            
        int iterationsCount = depthReadings.Length - depthReadings.Length % 3;
            
        for (int i = 1; i < iterationsCount; i++)
        {
            int currentDepthSum = 
                new MeasurementWindow(depthMeasurements[i], depthMeasurements[i + 1], depthMeasurements[i + 2])
                    .MeasurementSum();
            if (currentDepthSum > cachedDepthSum) depthIncreasedCount++;
            cachedDepthSum = currentDepthSum;
        }
        return depthIncreasedCount.ToString();
    }

    #region PartTwo
    private static void ConvertReadingsToIntMeasurements(string[] depthReadings, int[] depthMeasurements)
    {
        for (int i = 0; i < depthReadings.Length; i++)
        {
            depthMeasurements[i] = int.Parse(depthReadings[i]);
        }
    }

    private class MeasurementWindow
    {
        private int MeasurementOne {get; set;}
        private int MeasurementTwo {get; set;}
        private int MeasurementThree {get; set;}
        
        public MeasurementWindow(int firstMeasure, int secondMeasure, int thirdMeasure)
        {
            MeasurementOne = firstMeasure;
            MeasurementTwo = secondMeasure;
            MeasurementThree = thirdMeasure;
        }
        
        public int MeasurementSum()
        {
            return MeasurementOne + MeasurementTwo + MeasurementThree;
        }
    }
    #endregion
}

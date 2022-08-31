namespace AdventOfCode.Solutions.Year2021.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2021, "") { }

    protected override string SolvePartOne()
    {
        string[] depthReadingsText = Input.SplitByNewline();
        int[] depthMeasurements = new int[depthReadingsText.Length];
            
        ConvertReadingsToIntMeasurements(depthReadingsText, depthMeasurements);

        int cachedDepth = depthMeasurements[0];
            
        int depthIncreasedCount = 0;

        int iterationsCount = depthReadingsText.Length;
            
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
        string[] depthReadingsText = Input.SplitByNewline();
        int[] depthMeasurements = new int[depthReadingsText.Length];
            
        ConvertReadingsToIntMeasurements(depthReadingsText, depthMeasurements);

        int cachedDepthSum =
            new MeasurementWindow(depthMeasurements[0], depthMeasurements[1], depthMeasurements[2])
                .MeasurementSum();
            
        int depthIncreasedCount = 0;
            
        int iterationsCount = depthReadingsText.Length - depthReadingsText.Length % 3;
            
        for (int i = 1; i < iterationsCount; i++)
        {
            var currentMeasurement = new MeasurementWindow(
                depthMeasurements[i],
                depthMeasurements[i + 1],
                depthMeasurements[i + 2]);
            int currentDepthSum = currentMeasurement.MeasurementSum();
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
        private int MeasurementOne {get; }
        private int MeasurementTwo {get; }
        private int MeasurementThree {get; }
        
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

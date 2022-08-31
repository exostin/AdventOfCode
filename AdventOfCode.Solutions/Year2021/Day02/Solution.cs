using System.Diagnostics;

namespace AdventOfCode.Solutions.Year2021.Day02;

class Solution : SolutionBase
{
    public Solution() : base(02, 2021, "") { }

    protected override string SolvePartOne()
    {
        int horizontalPosition = 0;
        int depth = 0;
        
        // split inputs by newline into single commands
        var commands = new List<string>(Input.SplitByNewline());
        // loop through commands, and split them into <action> <value>
        foreach (string command in commands)
        {
            // read action
            string action = command.Split(" ")[0];
            // read action value
            int actionValue = int.Parse(command.Split(" ")[1]);
            // select appropriate action
            switch (action)
            {
                case "forward":
                    GoForward(actionValue, ref horizontalPosition);
                    break;
                case "up":
                    GoUp(actionValue, ref depth);
                    break;
                case "down":
                    GoDown(actionValue, ref depth);
                    break;
            }
        }
        return (horizontalPosition * depth).ToString();
    }

    private void GoDown(int actionValue, ref int depth)
    {
        depth += actionValue;
    }

    private void GoUp(int actionValue, ref int depth)
    {
        depth -= actionValue;
    }

    private void GoForward(int actionValue, ref int horizontalPosition)
    {
        horizontalPosition += actionValue;
    }

    protected override string SolvePartTwo()
    {
        int horizontalPosition = 0;
        int depth = 0;
        int aim = 0;
        
        // split inputs by newline into single commands
        var commands = new List<string>(Input.SplitByNewline());
        // loop through commands, and split them into <action> <value>
        foreach (string command in commands)
        {
            // read action
            string action = command.Split(" ")[0];
            // read action value
            int actionValue = int.Parse(command.Split(" ")[1]);
            // select appropriate action
            switch (action)
            {
                case "forward":
                    SwimForward(actionValue, ref horizontalPosition, ref depth, ref aim);
                    break;
                case "up":
                    AimUp(actionValue, ref aim);
                    break;
                case "down":
                    AimDown(actionValue, ref aim);
                    break;
            }
        }
        return (horizontalPosition * depth).ToString();
    }
    
    private void AimDown(int actionValue, ref int aim)
    {
        aim += actionValue;
    }

    private void AimUp(int actionValue, ref int aim)
    {
        aim -= actionValue;
    }

    private void SwimForward(int actionValue, ref int horizontalPosition, ref int depth, ref int aim)
    {
        horizontalPosition += actionValue;
        depth += aim * actionValue;
    }
}

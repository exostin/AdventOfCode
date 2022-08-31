using System.Diagnostics;

namespace AdventOfCode.Solutions.Year2021.Day02;

partial class Solution : SolutionBase
{
    private readonly PartOneActions _partOneActions;
    private readonly PartTwoActions _partTwoActions;

    public Solution() : base(02, 2021, "")
    {
        _partOneActions = new PartOneActions();
        _partTwoActions = new PartTwoActions();
    }

    protected override string SolvePartOne()
    {
        var partOneSubmarine = new Submarine(_partOneActions);
        var commands = Input.SplitByNewline();
        var result = partOneSubmarine.ExecuteCommands(commands).ToString();
        return result;
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
                    horizontalPosition += _partTwoActions.Forward(actionValue, aim, ref depth);
                    break;
                case "up":
                    aim -= _partTwoActions.Up(actionValue);
                    break;
                case "down":
                    aim += _partTwoActions.Down(actionValue);
                    break;
            }
        }
        return (horizontalPosition * depth).ToString();
    }
}

namespace AdventOfCode.Solutions.Year2021.Day02;

public class Submarine
{
    public Submarine(object actions)
    {
        Actions = actions;
    }
    private int HorizontalPosition { get; set; } = 0;
    private int Depth { get; set; } = 0;
    // TODO: generalize it
    private object Actions { get; set; }

    public int ExecuteCommands(IEnumerable<string> commands)
    {
        foreach (string command in commands)
        {
            string action = command.Split(" ")[0];
            int actionValue = int.Parse(command.Split(" ")[1]);
            // perform selected action
            switch (action)
            {
                case "forward":
                    HorizontalPosition += Actions.Forward(actionValue);
                    break;
                case "up":
                    Depth -= Actions.Up(actionValue);
                    break;
                case "down":
                    Depth += Actions.Down(actionValue);
                    break;
            }
        }
        return (HorizontalPosition * Depth).ToString();
    }
}
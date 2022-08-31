namespace AdventOfCode.Solutions.Year2021.Day02;

class PartTwoActions : IDownAction, IUpAction, IAimedForwardAction
{
    public int Down(int actionValue)
    {
        return actionValue;
    }

    public int Up(int actionValue)
    {
        return actionValue;
    }

    public int Forward(int actionValue, int aim, ref int depth)
    {
        depth += aim * actionValue;
        return actionValue;
    }
}
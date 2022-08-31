namespace AdventOfCode.Solutions.Year2021.Day02;

class PartOneActions : IDownAction, IUpAction, IForwardAction
{
    public int Down(int actionValue)
    {
        return actionValue;
    }

    public int Up(int actionValue)
    {
        return actionValue;
    }

    public int Forward(int actionValue)
    {
        return actionValue;
    }
}
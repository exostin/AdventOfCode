namespace AdventOfCode.Solutions.Year2021.Day02;

internal interface IDownAction
{
    int Down(int actionValue);
}

internal interface IUpAction
{
    int Up(int actionValue);
}

internal interface IForwardAction
{
    int Forward(int actionValue);
}

internal interface IAimedForwardAction
{
    int Forward(int actionValue, int aim, ref int depth);
}

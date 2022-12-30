namespace BalazorTicTacToe.Shared;

public sealed class SquareModel
{
    public SquareModel(int number)
    {
        if (number < 1 || number > 9)
        {
            throw new ArgumentException("Number must be between 1 and 9.");
        }

        Number = number;
    }

    public int Number { get; }
    public PlayerSign? PlayerSign { get; set; }
    public bool Highlight { get; set; }
}
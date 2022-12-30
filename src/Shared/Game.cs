namespace BalazorTicTacToe.Shared;

public sealed class Game
{
    public Game()
    {
        Reset();
    }

    public SquareModelList Squares { get; private set; } = new();
    public PlayerSign NextSign { get; set; } = PlayerSign.X;
    public PlayerSign? Winner { get; set; }

    public void Move()
    {
        Winner = Squares.CheckWinner();
        NextSign = Winner ?? (NextSign == PlayerSign.O ? PlayerSign.X : PlayerSign.O);
    }

    public void Reset()
    {
        Squares.ReInitialize();
        NextSign = PlayerSign.X;
        Winner = null;
    }
}
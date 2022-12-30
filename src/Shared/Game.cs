namespace BalazorTicTacToe.Shared;

public sealed class Game
{
    private bool _isComputerGame = false;

    public Game(bool isComputerGame)
    {
        Reset(isComputerGame);
    }

    public SquareModelList Squares { get; private set; } = new();
    public PlayerSign NextSign { get; set; } = PlayerSign.X;
    public PlayerSign? Winner { get; set; }

    public void Move()
    {
        Winner = Squares.CheckWinner();
        NextSign = Winner ?? (NextSign == PlayerSign.O ? PlayerSign.X : PlayerSign.O);

        if (_isComputerGame && !Winner.HasValue)
        {
            AutoMove();
            Winner = Squares.CheckWinner();
            NextSign = Winner ?? (NextSign == PlayerSign.O ? PlayerSign.X : PlayerSign.O);
        }
    }

    public void Reset(bool isComputerGame)
    {
        _isComputerGame = isComputerGame;
        Squares.ReInitialize();
        NextSign = PlayerSign.X;
        Winner = null;
    }

    public void AutoMove()
    {
        var model = Squares.GetNextMove(NextSign);
        model.PlayerSign = NextSign;
    }
}
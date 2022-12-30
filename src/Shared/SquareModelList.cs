namespace BalazorTicTacToe.Shared;

public sealed class SquareModelList
{
    private readonly List<SquareModel> _list = new();
    private readonly List<WinningCombination> _winners = new()
    {
        new WinningCombination(1, 2, 3),
        new WinningCombination(4, 5, 6),
        new WinningCombination(7, 8, 9),
        new WinningCombination(1, 4, 7),
        new WinningCombination(2, 5, 8),
        new WinningCombination(3, 6, 9),
        new WinningCombination(1, 5, 9),
        new WinningCombination(3, 5, 7)
    };

    public SquareModelList()
    {
        ReInitialize();
    }

    public IReadOnlyList<SquareModel> Squares => _list.AsReadOnly();

    public void ReInitialize()
    {
        _list.Clear();

        for (var i = 1; i <= 9; i++)
        {
            _list.Add(new(i));
        }
    }

    public PlayerSign? CheckWinner()
    {
        foreach (var winner in _winners)
        {
            if (HasWinner(PlayerSign.O, winner))
            {
                return PlayerSign.O;
            }
            else if (HasWinner(PlayerSign.X, winner))
            {
                return PlayerSign.X;
            }
        }

        return null;
    }

    private bool HasWinner(PlayerSign playerSign, WinningCombination winner)
    {
        var hasWinner = _list[winner.Square1 - 1].PlayerSign == playerSign && _list[winner.Square2 - 1].PlayerSign == playerSign && _list[winner.Square3 - 1].PlayerSign == playerSign;

        if (hasWinner)
        {
            _list[winner.Square1 - 1].Highlight = true;
            _list[winner.Square2 - 1].Highlight = true;
            _list[winner.Square3 - 1].Highlight = true;
        }

        return hasWinner;
    }

    public SquareModel GetNextMove(PlayerSign playerSign)
    {
        foreach (var winner in _winners)
        {
            var model = NextWinnerForMe(playerSign, _list[winner.Square1 - 1], _list[winner.Square2 - 1], _list[winner.Square3 - 1]);

            if (model != null)
            {
                return model;
            }

            model = NextWinnerForTheOpponent(playerSign, _list[winner.Square1 - 1], _list[winner.Square2 - 1], _list[winner.Square3 - 1]);


            if (model != null)
            {
                return model;
            }
        }

        return _list.First(m => m.PlayerSign == null);
    }
    private SquareModel? NextWinnerForMe(PlayerSign sign, SquareModel model1, SquareModel model2, SquareModel model3)
    {
        return NextWinner(sign, model1, model2, model3);
    }
    private SquareModel? NextWinnerForTheOpponent(PlayerSign sign, SquareModel model1, SquareModel model2, SquareModel model3)
    {
        return NextWinner(sign == PlayerSign.O ? PlayerSign.X : PlayerSign.O, model1, model2, model3);
    }

    private SquareModel? NextWinner(PlayerSign sign, SquareModel model1, SquareModel model2, SquareModel model3)
    {
        int setCount = 0;
        int nullCount = 0;
        SquareModel? modelToSet = null;

        setCount += model1.PlayerSign == sign ? 1 : 0;
        setCount += model2.PlayerSign == sign ? 1 : 0;
        setCount += model3.PlayerSign == sign ? 1 : 0;

        if (model1.PlayerSign == null)
        {
            nullCount++;
            modelToSet = model1;
        }

        if (model2.PlayerSign == null)
        {
            nullCount++;
            modelToSet = model2;
        }

        if (model3.PlayerSign == null)
        {
            nullCount++;
            modelToSet = model3;
        }

        return setCount == 2 && nullCount == 1 ? modelToSet : null;
    }
}

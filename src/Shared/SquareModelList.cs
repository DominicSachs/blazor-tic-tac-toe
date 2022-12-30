namespace BalazorTicTacToe.Shared
{
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

        public void Clear()
        {
            _list.Clear();
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
    }
}

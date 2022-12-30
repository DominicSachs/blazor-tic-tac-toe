using BalazorTicTacToe.Shared;

namespace BalazorTicTacToe.Client.Pages;

public partial class Board
{
    private Game _game = default!;
    private IReadOnlyList<SquareModel> _squares = default!;

    protected override Task OnInitializedAsync()
    {
        _game = new(false);
        _squares = _game.Squares.Squares;

        return base.OnInitializedAsync();
    }

    public void SquareClicked(SquareModel model)
    {
        if (!_game.Winner.HasValue)
        {
            model.PlayerSign = _game.NextSign;
            _game.Move();
        }
    }

    public void StartNew(bool isComputerGame)
    {
        _game.Reset(isComputerGame);
        StateHasChanged();
    }
}
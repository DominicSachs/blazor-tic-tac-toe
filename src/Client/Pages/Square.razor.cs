using BalazorTicTacToe.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BalazorTicTacToe.Client.Pages;

public partial class Square
{
    [Parameter, EditorRequired]
    public SquareModel Model { get; set; } = null!;

    [Parameter]
    public EventCallback<SquareModel> ClickAction { get; set; }

    private void SetValue(MouseEventArgs mouseEventArgs)
    {
        if (Model.PlayerSign == null)
        {
            ClickAction.InvokeAsync(Model);
        }
    }
}
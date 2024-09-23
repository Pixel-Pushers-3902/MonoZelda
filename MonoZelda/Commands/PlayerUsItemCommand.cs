using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class PlayerUseItemCommand : ICommand
{
    IController controller;
    int itemIdx;
    public PlayerUseItemCommand()
    {
    }

    public GameState Execute()
    {
        // Swap player item idx to itemIdx
        Debug.WriteLine("Changing player item to " + itemIdx);

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }

    public void SetItemIndex(int itemIdx)
    {
        this.itemIdx = itemIdx;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

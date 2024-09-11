using System;
using System.Diagnostics;

namespace LevelBasedGame.Commands;
public class PlayerUseItem : ICommand
{
    IController controller;
    int itemIdx;
    public PlayerUseItem(IController controller, int itemIdx)
    {
        this.controller = controller;
        this.itemIdx = itemIdx;
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
}

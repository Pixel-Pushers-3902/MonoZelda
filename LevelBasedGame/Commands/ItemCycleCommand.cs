using System;
using System.Diagnostics;
using System.Numerics;

namespace LevelBasedGame.Commands;
public class ItemCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    public ItemCycleCommand(IController controller, int cycleAddition)
    {
        this.controller = controller;
        this.cycleAddition = cycleAddition;
    }

    public GameState Execute()
    {
        // Apply cycle addition to item list
        Debug.WriteLine("Item list cycling by " + cycleAddition);

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

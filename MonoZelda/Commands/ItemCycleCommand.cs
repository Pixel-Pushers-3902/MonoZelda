using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class ItemCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    public ItemCycleCommand()
    {
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

    public void SetCycleAddition(int cycleAddition)
    {
        this.cycleAddition = cycleAddition;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

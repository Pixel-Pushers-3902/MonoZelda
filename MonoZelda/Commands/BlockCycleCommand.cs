using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class BlockCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    public BlockCycleCommand(IController controller, int cycleAddition)
    {
        this.controller = controller;
        this.cycleAddition = cycleAddition;
    }

    public GameState Execute()
    {
        // Apply cycle addition to block list
        Debug.WriteLine("Block list cycling by " + cycleAddition);

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

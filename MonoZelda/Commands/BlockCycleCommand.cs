using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class BlockCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    public BlockCycleCommand()
    {
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

    public void SetCycleAddition(int cycleAddition)
    {
        this.cycleAddition = cycleAddition;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

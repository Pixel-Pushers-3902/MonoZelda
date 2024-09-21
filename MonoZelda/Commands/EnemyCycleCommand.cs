using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class EnemyCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    public EnemyCycleCommand(IController controller, int cycleAddition)
    {
        this.controller = controller;
        this.cycleAddition = cycleAddition;
    }

    public GameState Execute()
    {
        // Apply cycle addition to enemy list
        myGame.enemyController.Update(cycleAddition);

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

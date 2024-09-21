using System;
using System.Diagnostics;
using MonoZelda.Controllers;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class EnemyCycleCommand : ICommand
{
    IController controller;
    EnemyController enemyCycler;
    int cycleAddition;
    public EnemyCycleCommand()
    {
    }

    public GameState Execute()
    {
        // Apply cycle addition to enemy list
        enemyCycler.SetCycle(cycleAddition);
        enemyCycler.Update();

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

    public void SetCycler(EnemyController enemyController)
    {
        enemyCycler = enemyController;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

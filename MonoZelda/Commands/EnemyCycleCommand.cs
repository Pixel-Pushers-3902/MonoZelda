using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class EnemyCycleCommand : ICommand
{
    private readonly IController controller;
    private readonly int cycleAddition;
    private readonly MonoZeldaGame myGame;
    public EnemyCycleCommand(IController controller, int cycleAddition, MonoZeldaGame game)
    {
        this.controller = controller;
        this.cycleAddition = cycleAddition;
        myGame = game;
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
}

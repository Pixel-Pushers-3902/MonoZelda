using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class EnemyCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    private MonoZeldaGame myGame;
    public EnemyCycleCommand(IController controller, int cycleAddition, MonoZeldaGame game)
    {
        this.controller = controller;
        this.cycleAddition = cycleAddition;
        myGame = game;
    }

    public GameState Execute()
    {
        // Apply cycle addition to enemy list
        myGame.enemyController.CycleEnemy(cycleAddition);
        myGame.enemy = myGame.enemyController.SetEnemy();

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

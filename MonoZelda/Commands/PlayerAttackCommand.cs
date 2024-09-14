using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class PlayerAttackCommand : ICommand
{
    IController controller;
    int attackIdx;
    public PlayerAttackCommand(IController controller, int attackIdx)
    {
        this.controller = controller;
        this.attackIdx = attackIdx;
    }

    public GameState Execute()
    {
        // Perform state change for player to attack
        Debug.WriteLine("Player using attack " + attackIdx);

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class PlayerTakeDamageCommand : ICommand
{
    IController controller;
    int damage;
    public PlayerTakeDamageCommand(IController controller, int damage)
    {
        this.controller = controller;
        this.damage = damage;
    }

    public GameState Execute()
    {
        // Apply damage to player
        Debug.WriteLine("Player taking " + damage + " units of damage");

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

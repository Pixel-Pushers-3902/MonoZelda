using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class PlayerTakeDamageCommand : ICommand
{
    IController controller;
    int damage;
    public PlayerTakeDamageCommand()
    {
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

    public void SetDamage(int damage) 
    {
        this.damage = damage;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

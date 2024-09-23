﻿using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class PlayerMoveCommand : ICommand
{
    IController controller;
    Vector2 scalarVector;
    public PlayerMoveCommand()
    {
    }

    public GameState Execute()
    {
        // Apply movement to player
        Debug.WriteLine("Applying scalar vector " + scalarVector + " to player");

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }

    public void SetScalarVector(Vector2 scalarVector)
    {
        this.scalarVector = scalarVector;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

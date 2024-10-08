﻿using System;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class ExitCommand : ICommand
{
    private Game _game;

    IController controller;
    public ExitCommand()
    {
    }

    public ExitCommand(Game game)
    {
        _game = game;
    }

    public GameState Execute()
    {
        _game.Exit();

        return GameState.Quit;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

using LevelBasedGame.Commands;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace LevelBasedGame.Controllers;
public class MouseController : IController
{

    private MouseState mouseState;
    private GameState gameState;

    public MouseController()
    {
        gameState = GameState.Start;
    }

    // Properties
    public MouseState MouseState
    {
        get
        {
            return mouseState;
        }
        set
        {
            mouseState = value;
        }
    }

    public GameState GameState
    {
        get
        {
            return gameState;
        }
        set
        {
            gameState = value;
        }
    }


    public bool Update()
    {
        GameState newState = gameState;

        // Mouse input logic goes here

        // Setting new Game State of mouse controller if needed
        if (gameState != newState)
        {
            gameState = newState;
            return true;
        }
        return false;
    }

}
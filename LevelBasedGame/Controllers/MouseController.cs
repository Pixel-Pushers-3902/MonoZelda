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
        if (mouseState.RightButton == ButtonState.Pressed)
        {
            ICommand exitCommand = new ExitCommand(this);
            newState = exitCommand.Execute();
        }
        else if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (mouseState.X < 400 && mouseState.Y < 240)
            {
                ICommand stillCommand = new StillCommand(this);
                newState = stillCommand.Execute();
            }
            else if (mouseState.X >= 400 && mouseState.Y <= 240)
            {
                ICommand stillAnimatedCommand = new StillAnimatedCommand(this);
                newState = stillAnimatedCommand.Execute();
            }
            else if (mouseState.X < 400 && mouseState.Y > 240)
            {
                ICommand movingCommand = new MovingCommand(this);
                newState = movingCommand.Execute();
            }
            else if (mouseState.X >= 400 && mouseState.Y >= 240)
            {
                ICommand movingAnimatedCommand = new MovingAnimatedCommand(this);
                newState = movingAnimatedCommand.Execute();
            }

        }

        if (gameState != newState)
        {
            gameState = newState;
            return true;
        }
        return false;
    }

}
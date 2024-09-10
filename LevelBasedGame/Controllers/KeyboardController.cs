using LevelBasedGame.Commands;
using Microsoft.Xna.Framework.Input;
using System;

namespace LevelBasedGame.Controllers;
public class KeyboardController : IController
{

    private KeyboardState keyboardState;
    private GameState gameState;

    public KeyboardController()
    {
        gameState = GameState.Start;
}

    // Properties
    public KeyboardState KeyboardState
    {
        get
        {
            return keyboardState;
        }
        set
        {
            keyboardState = value;
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
        if (keyboardState.IsKeyDown(Keys.D0))
        {
            ICommand exitCommand = new ExitCommand(this);
            newState = exitCommand.Execute();
        }
        else if (keyboardState.IsKeyDown(Keys.D1))
        {
            ICommand stillCommand = new StillCommand(this);
            newState = stillCommand.Execute();
        }
        else if (keyboardState.IsKeyDown(Keys.D2))
        {
            ICommand stillAnimatedCommand = new StillAnimatedCommand(this);
            newState = stillAnimatedCommand.Execute();
        }
        else if (keyboardState.IsKeyDown(Keys.D3))
        {
            ICommand movingCommand = new MovingCommand(this);
            newState = movingCommand.Execute();
        }
        else if (keyboardState.IsKeyDown(Keys.D4))
        {
            ICommand movingAnimatedCommand = new MovingAnimatedCommand(this);
            newState = movingAnimatedCommand.Execute();
            newState = movingAnimatedCommand.Execute();
        }
        if (gameState != newState)
        {
            gameState = newState;
            return true;
        }
        return false;
    }

}

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
        if (keyboardState.IsKeyDown(Keys.Q))
        {
            // Exit Command
            ICommand exitCommand = new ExitCommand(this);
            newState = exitCommand.Execute();
        }
        else if (keyboardState.IsKeyDown(Keys.R))
        {
            // Reset Command
            ICommand resetCommand = new ResetCommand(this);
            newState = resetCommand.Execute();
        }
        else
        {
            // Check for Player item swap input
            if (keyboardState.IsKeyDown(Keys.D1))
            {
                // Player item 1 equip
                ICommand playerUseItem = new PlayerUseItem(this, 1);
                newState = playerUseItem.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.D2))
            {
                // Player item 2 equip
                ICommand playerUseItem = new PlayerUseItem(this, 2);
                newState = playerUseItem.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.D3))
            {
                // Player item 3 equip
                ICommand playerUseItem = new PlayerUseItem(this, 3);
                newState = playerUseItem.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.D4))
            {
                // Player item 4 equip
                ICommand playerUseItem = new PlayerUseItem(this, 4);
                newState = playerUseItem.Execute();
            }

            // Check for Player movement input

            // Check for Player attack input

            // Check for Player damage applied

            // Check for Block / Obstacle cycle input

            // Check for Item cycle input

            // Check for Enemy / NPC cycle input

        }

        // Setting new Game State of keyboard controller if needed
        if (gameState != newState)
        {
            gameState = newState;
            return true;
        }
        return false;
    }

}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Commands;

namespace PixelPushers.MonoZelda.Controllers;

public class KeyboardController : IController
{
    private KeyboardState previousKeyboardState;
    private KeyboardState currentKeyboardState;
    private GameState gameState;

    // TODO: Hack to expose the block commands
    public ICommand BlockCycleCommand;

    public KeyboardController()
    {
        gameState = GameState.Start;
}

    // Properties
    public KeyboardState CurrentKeyboardState
    {
        get
        {
            return currentKeyboardState;
        }
        set
        {
            currentKeyboardState = value;
        }
    }

    public KeyboardState PreviousKeyboardState
    {
        get
        {
            return previousKeyboardState;
        }
        set
        {
            previousKeyboardState = value;
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
        if (currentKeyboardState.IsKeyDown(Keys.Q))
        {
            // Exit Command
            ICommand exitCommand = new ExitCommand(this);
            newState = exitCommand.Execute();
        }
        else if (OneShotPressed(Keys.R))
        {
            // Reset Command
            ICommand resetCommand = new ResetCommand(this);
            newState = resetCommand.Execute();
        }
        else
        {
            // Check for Player item swap input
            if (OneShotPressed(Keys.D1))
            {
                // Player item 1 equip
                ICommand playerUseItem = new PlayerUseItem(this, 1);
                newState = playerUseItem.Execute();
            }
            else if (OneShotPressed(Keys.D2))
            {
                // Player item 2 equip
                ICommand playerUseItem = new PlayerUseItem(this, 2);
                newState = playerUseItem.Execute();
            }
            else if (OneShotPressed(Keys.D3))
            {
                // Player item 3 equip
                ICommand playerUseItem = new PlayerUseItem(this, 3);
                newState = playerUseItem.Execute();
            }
            else if (OneShotPressed(Keys.D4))
            {
                // Player item 4 equip
                ICommand playerUseItem = new PlayerUseItem(this, 4);
                newState = playerUseItem.Execute();
            }

            // Check for Player movement input
            if (currentKeyboardState.IsKeyDown(Keys.W) || currentKeyboardState.IsKeyDown(Keys.Up))
            {
                // Player move forward command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(1, 0));
                newState = playerMoveCommand.Execute();
            }
            else if (currentKeyboardState.IsKeyDown(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Down))
            {
                // Player move backward command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(-1, 0));
                newState = playerMoveCommand.Execute();
            }
            else if (currentKeyboardState.IsKeyDown(Keys.D) || currentKeyboardState.IsKeyDown(Keys.Right))
            {
                // Player move right command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(0, 1));
                newState = playerMoveCommand.Execute();
            }
            else if (currentKeyboardState.IsKeyDown(Keys.A) || currentKeyboardState.IsKeyDown(Keys.Left))
            {
                // Player move left command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(0, -1));
                newState = playerMoveCommand.Execute();
            }

            // Check for Player attack input
            if (OneShotPressed(Keys.Z))
            {
                // Player primary attack
                ICommand playerAttackCommand = new PlayerAttackCommand(this, 1);
                newState = playerAttackCommand.Execute();
            }
            else if (OneShotPressed(Keys.N))
            {
                // Player primary attack
                ICommand playerAttackCommand = new PlayerAttackCommand(this, 2);
                newState = playerAttackCommand.Execute();
            }

            // Check for Player damage applied
            if (OneShotPressed(Keys.E))
            {
                ICommand playerTakeDamageCommand = new PlayerTakeDamageCommand(this, 10);
                newState = playerTakeDamageCommand.Execute();
            }

            // Check for Block / Obstacle cycle input
            if (OneShotPressed(Keys.Y))
            {
                BlockCycleCommand.Execute();
            }
            else if (OneShotPressed(Keys.T))
            {
                BlockCycleCommand.UnExecute();
            }

            // Check for Item cycle input
            if (OneShotPressed(Keys.I))
            {
                ICommand itemCycleCommand = new ItemCycleCommand(this, 1);
                newState = itemCycleCommand.Execute();
            }
            else if (OneShotPressed(Keys.U))
            {
                ICommand itemCycleCommand = new ItemCycleCommand(this, -1);
                newState = itemCycleCommand.Execute();
            }

            // Check for Enemy / NPC cycle input
            if (OneShotPressed(Keys.P))
            {
                ICommand enemyCycleCommand = new EnemyCycleCommand(this, 1);
                newState = enemyCycleCommand.Execute();
            }
            else if (OneShotPressed(Keys.O))
            {
                ICommand enemyCycleCommand = new EnemyCycleCommand(this, -1);
                newState = enemyCycleCommand.Execute();
            }
        }

        // Update previous keyboard state (Do after all keyboard checks)
        previousKeyboardState = currentKeyboardState;

        // Setting new Game State of keyboard controller if needed
        if (gameState != newState)
        {
            gameState = newState;
            return true;
        }
        return false;
    }

    public bool OneShotPressed(Keys key)
    {
        if (currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key))
        {
            return true;
        }
        return false;
}
}

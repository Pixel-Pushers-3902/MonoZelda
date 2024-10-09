using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Link.Projectiles;
using System.Collections.Generic;

namespace PixelPushers.MonoZelda.Controllers;

public class KeyboardController : IController
{
    private KeyboardState previousKeyboardState;
    private KeyboardState currentKeyboardState;
    private GameState gameState;
    private CommandManager commandManager;
    private ProjectileManager projectileManager;

    public KeyboardController(CommandManager commandManager)
    {
        gameState = GameState.Title;
        this.commandManager = commandManager;
        projectileManager = new ProjectileManager();
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

    private void PlayerMovementStatusUpdate()
    {
        var movementMap = new Dictionary<Keys, Vector2>
        {
           { Keys.W, new Vector2(0, -1) },   // Move forward
           { Keys.Up, new Vector2(0, -1) },  // Move forward
           { Keys.S, new Vector2(0, 1) },    // Move backward
           { Keys.Down, new Vector2(0, 1) }, // Move backward
           { Keys.D, new Vector2(1, 0) },    // Move right
           { Keys.Right, new Vector2(1, 0) },// Move right
           { Keys.A, new Vector2(-1, 0) },   // Move left
           { Keys.Left, new Vector2(-1, 0) } // Move left
        };

        PlayerMoveCommand playerMoveCommand = (PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand];

        // Check for movement input
        foreach (var move in movementMap)
        {
            if (currentKeyboardState.IsKeyDown(move.Key))
            {
                playerMoveCommand.SetScalarVector(move.Value);
                playerMoveCommand.Execute();
                return; // Break early once a movement key is detected
            }
        }

        // If no movement key is pressed, execute standing command
        PlayerStandingCommand playerStandingCommand = (PlayerStandingCommand)commandManager.CommandMap[CommandEnum.PlayerStandingCommand];
        playerStandingCommand.Execute();
    }

    private void PlayerProjectileStatusUpdate()
    {
        var keyProjectileMap = new Dictionary<Keys, int>
        {
           { Keys.D1, 1 }, // Green Arrow
           { Keys.D2, 2 }, // Blue Arrow
           { Keys.D3, 3 }, // Boomerang
           { Keys.D4, 4 }, // Blue Boomerang
           { Keys.D5, 5 }, // Bomb
           { Keys.D6, 6 }  // Blue Candle
        };

        PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];

        foreach (var keyProjectilePair in keyProjectileMap)
        {
            if (OneShotPressed(keyProjectilePair.Key) && !projectileManager.ProjectileFired)
            {
                playerUseItemCommand.CreateProjectile(keyProjectilePair.Value, projectileManager);
                playerUseItemCommand.Execute();
                break; // Stop checking after the first valid key is pressed
            }
        }

        projectileManager.executeProjectile();
    }

    private void PlayerAttackStatusUpdate()
    {
        PlayerAttackCommand playerAttackCommand = (PlayerAttackCommand)commandManager.CommandMap[CommandEnum.PlayerAttackCommand];

        // Check for player attack status
        if (OneShotPressed(Keys.Z))
        {
            playerAttackCommand.SetAttackIndex(0);
            playerAttackCommand.Execute();
        }
        else if (OneShotPressed(Keys.N))
        {
            playerAttackCommand.SetAttackIndex(1);
            playerAttackCommand.Execute();
        }
    }

    private void ExitAndResetUpdate()
    {
        if (currentKeyboardState.IsKeyDown(Keys.Q))
        {
            // Exit Command
            commandManager.Execute(CommandEnum.ExitCommand);
        }
        else if (OneShotPressed(Keys.R))
        {
            // Reset Command
            commandManager.Execute(CommandEnum.ResetCommand);
        }
    }

    public bool Update()
    {
        currentKeyboardState = Keyboard.GetState();
        GameState newState = gameState;

        // Check for Start game 
        if (OneShotPressed(Keys.Enter))
        {
            newState = commandManager.Execute(CommandEnum.StartGameCommand);
        }

        // Set controller for all commands
        commandManager.SetController(this);

        // Check for all game object updates
        PlayerMovementStatusUpdate();
        PlayerAttackStatusUpdate();
        PlayerProjectileStatusUpdate();
        ExitAndResetUpdate();

        // Update previous keyboard state (Do after all keyboard checks)
        previousKeyboardState = currentKeyboardState;

        // Setting new Game State of keyboard controller if needed
        return (gameState != newState) ? (gameState = newState) == newState : false;
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


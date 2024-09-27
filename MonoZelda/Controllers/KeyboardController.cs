using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Link;
using PixelPushers.MonoZelda.Commands;
using System.Diagnostics;


namespace PixelPushers.MonoZelda.Controllers;

public class KeyboardController : IController
{
    private KeyboardState previousKeyboardState;
    private KeyboardState currentKeyboardState;
    private GameState gameState;
    private CommandManager commandManager;
    private bool projectileFired;
    private PlayerUseItemCommand projectileCommand;

    //temp
    private int attackFrames;

    public KeyboardController(CommandManager commandManager)
    {
        gameState = GameState.Title;
        attackFrames = 0;
        this.commandManager = commandManager;
        projectileFired = false;
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
        commandManager.SetController(this);
        GameState newState = gameState;
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
        else
        {
            if (projectileFired)
            {
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
                projectileFired = !(projectileCommand.getProjectileState());
            }

            // Player attack input
            if (attackFrames > 0)
            {
                PlayerAttackCommand playerAttackCommand = (PlayerAttackCommand)commandManager.CommandMap[CommandEnum.PlayerAttackCommand];
                playerAttackCommand.SetAttackIndex(0);
                commandManager.Execute(CommandEnum.PlayerAttackCommand);
                attackFrames--; // Decrement the hold counter
            }
            
            // Check for Player item swap input
            if (OneShotPressed(Keys.D1) && !projectileFired)
            {
                // Player item 1 equip. Normal Arrow
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetProjectile(1);
                projectileFired = true;
                projectileCommand = playerUseItemCommand;
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D2) && !projectileFired)
            {
                // Player item 2 equip. Blue Arrow
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetProjectile(2);
                projectileFired = true;
                projectileCommand = playerUseItemCommand;
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D3) && !projectileFired)
            {
                // Player item 3 equip. Boomerang
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetProjectile(3);
                projectileFired = true;
                projectileCommand = playerUseItemCommand;
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D4) && !projectileFired)
            {
                // Player item 4 equip. Blue Boomerang
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetProjectile(4);
                projectileFired = true;
                projectileCommand = playerUseItemCommand;
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D5) && !projectileFired)
            {
                // Player item 5 equip. Bomb
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetProjectile(5);
                projectileFired = true;
                projectileCommand = playerUseItemCommand;
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D6) && !projectileFired)
            {
                // Player item 6 equip. Blue Candle
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetProjectile(6);
                projectileFired = true;
                projectileCommand = playerUseItemCommand;
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.Enter))
            {
                newState = commandManager.Execute(CommandEnum.StartGame);
            }
            else
            if (attackFrames == 0)
            {
                // Check for Player movement input
                if (currentKeyboardState.IsKeyDown(Keys.W) || currentKeyboardState.IsKeyDown(Keys.Up))
                {
                    // Player move forward command
                    PlayerMoveCommand playerMoveCommand = (PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand];
                    playerMoveCommand.SetScalarVector(new Vector2(0, -1));
                    commandManager.Execute(CommandEnum.PlayerMoveCommand);
                }
                else if (currentKeyboardState.IsKeyDown(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Down))
                {
                    // Player move backward command
                    PlayerMoveCommand playerMoveCommand = (PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand];
                    playerMoveCommand.SetScalarVector(new Vector2(0, 1));
                    commandManager.Execute(CommandEnum.PlayerMoveCommand);
                }
                else if (currentKeyboardState.IsKeyDown(Keys.D) || currentKeyboardState.IsKeyDown(Keys.Right))
                {
                    // Player move right command
                    PlayerMoveCommand playerMoveCommand = (PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand];
                    playerMoveCommand.SetScalarVector(new Vector2(1, 0));
                    commandManager.Execute(CommandEnum.PlayerMoveCommand);
                }
                else if (currentKeyboardState.IsKeyDown(Keys.A) || currentKeyboardState.IsKeyDown(Keys.Left))
                {
                    // Player move left command
                    PlayerMoveCommand playerMoveCommand = (PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand];
                    playerMoveCommand.SetScalarVector(new Vector2(-1, 0));
                    commandManager.Execute(CommandEnum.PlayerMoveCommand);
                }
                else
                {
                    // Player move left
                    PlayerStandingCommand playerStandingCommand = (PlayerStandingCommand)commandManager.CommandMap[CommandEnum.PlayerStandingCommand];
                    commandManager.Execute(CommandEnum.PlayerStandingCommand);
                    
                }
            }
           

            // Check for Player attack input
            if (OneShotPressed(Keys.Z))
            {
                
                attackFrames = 20; 
            }
            else if (OneShotPressed(Keys.N))
            {
                attackFrames = 20;
            }

            // Check for Player damage applied
            if (OneShotPressed(Keys.E))
            {
                PlayerTakeDamageCommand playerTakeDamageCommand = (PlayerTakeDamageCommand) commandManager.CommandMap[CommandEnum.PlayerTakeDamageCommand];
                playerTakeDamageCommand.SetDamage(10);
                commandManager.Execute(CommandEnum.PlayerTakeDamageCommand);
            }

            // Check for Block / Obstacle cycle input
            if (OneShotPressed(Keys.Y))
            {
                var cycleCommand = (BlockCycleCommand)commandManager.CommandMap[CommandEnum.BlockCycleCommand];
                cycleCommand.SetCycleAddition(1);
                cycleCommand.Execute();
            }
            else if (OneShotPressed(Keys.T))
            {
                var cycleCommand = (BlockCycleCommand)commandManager.CommandMap[CommandEnum.BlockCycleCommand];
                cycleCommand.SetCycleAddition(-1);
                cycleCommand.Execute();
            }

            // Check for Item cycle input
            if (OneShotPressed(Keys.I))
            {
                var cycleCommand = (ItemCycleCommand)commandManager.CommandMap[CommandEnum.ItemCycleCommand];
                cycleCommand.SetCycleAddition(1);
                cycleCommand.Execute();
            }
            else if (OneShotPressed(Keys.U))
            {
                var cycleCommand = (ItemCycleCommand)commandManager.CommandMap[CommandEnum.ItemCycleCommand];
                cycleCommand.SetCycleAddition(-1);
                cycleCommand.Execute();
            }

            // Check for Enemy / NPC cycle input
            if (OneShotPressed(Keys.P))
            {
                EnemyCycleCommand enemyCycleCommand = (EnemyCycleCommand) commandManager.CommandMap[CommandEnum.EnemyCycleCommand];
                enemyCycleCommand.SetCycleAddition(1);
                commandManager.Execute(CommandEnum.EnemyCycleCommand);
            }
            else if (OneShotPressed(Keys.O))
            {
                EnemyCycleCommand enemyCycleCommand = (EnemyCycleCommand) commandManager.CommandMap[CommandEnum.EnemyCycleCommand];
                enemyCycleCommand.SetCycleAddition(-1);
                commandManager.Execute(CommandEnum.EnemyCycleCommand);
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

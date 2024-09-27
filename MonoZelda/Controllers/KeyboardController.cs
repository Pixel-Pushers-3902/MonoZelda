using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoZelda.Player;
using PixelPushers.MonoZelda.Commands;
using System.Diagnostics;
using System.Diagnostics.Tracing;


namespace PixelPushers.MonoZelda.Controllers;

public class KeyboardController : IController
{
    private KeyboardState previousKeyboardState;
    private KeyboardState currentKeyboardState;
    private GameState gameState;
    private CommandManager commandManager;

    public KeyboardController(CommandManager commandManager)
    {
        gameState = GameState.Title;
        this.commandManager = commandManager;
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
            // Check for Player item swap input
            if (OneShotPressed(Keys.D1))
            {
                // Player item 1 equipd
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetItemIndex(1);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D2))
            {
                // Player item 2 equip
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetItemIndex(2);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D3))
            {
                // Player item 3 equip
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetItemIndex(3);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D4))
            {
                // Player item 4 equip
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.SetItemIndex(4);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.Enter))
            {
                newState = commandManager.Execute(CommandEnum.StartGame);
            }
            else
      
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
            
           

            // Check for Player attack input
            if (OneShotPressed(Keys.Z))
            {

                PlayerAttackCommand playerAttackCommand = (PlayerAttackCommand)commandManager.CommandMap[CommandEnum.PlayerAttackCommand];
                playerAttackCommand.SetAttackIndex(0);
                commandManager.Execute(CommandEnum.PlayerAttackCommand);
            }
            else if (OneShotPressed(Keys.N))
            {
                PlayerAttackCommand playerAttackCommand = (PlayerAttackCommand)commandManager.CommandMap[CommandEnum.PlayerAttackCommand];
                playerAttackCommand.SetAttackIndex(1);
                commandManager.Execute(CommandEnum.PlayerAttackCommand);
            }

            // Check for Player damage applied
            if (OneShotPressed(Keys.E))
            {
                PlayerTakeDamageCommand playerTakeDamageCommand = (PlayerTakeDamageCommand)commandManager.CommandMap[CommandEnum.PlayerTakeDamageCommand];
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

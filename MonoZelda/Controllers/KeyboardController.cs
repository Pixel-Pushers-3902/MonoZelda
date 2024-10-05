using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Link.Projectiles;


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

    public bool Update()
    {
        currentKeyboardState = Keyboard.GetState();

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
            // this line makes sure playerUseItemCommand.Execute() is called in each update, if a projectile has been fired,
            // so that it can keep moving
            projectileManager.executeProjectile();

            // Check for Player item swap input
            if (OneShotPressed(Keys.D1) && !projectileManager.ProjectileFired)
            {
                // Player item 1 equip. Green Arrow
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.CreateProjectile(1,projectileManager);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D2) && !projectileManager.ProjectileFired)
            {
                // Player item 2 equip. Blue Arrow
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.CreateProjectile(2,projectileManager);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D3) && !projectileManager.ProjectileFired)
            {
                // Player item 3 equip. Boomerang
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.CreateProjectile(3,projectileManager);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D4) && !projectileManager.ProjectileFired)
            {
                // Player item 4 equip. Blue Boomerang
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand) commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.CreateProjectile(4,projectileManager);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D5) && !projectileManager.ProjectileFired)
            {
                // Player item 5 equip. Bomb
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.CreateProjectile(5,projectileManager);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.D6) && !projectileManager.ProjectileFired)
            {
                // Player item 6 equip. Blue Candle
                PlayerUseItemCommand playerUseItemCommand = (PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand];
                playerUseItemCommand.CreateProjectile(6,projectileManager);
                commandManager.Execute(CommandEnum.PlayerUseItemCommand);
            }
            else if (OneShotPressed(Keys.Enter))
            {
                newState = commandManager.Execute(CommandEnum.StartCommand);
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
                    // Player stay still
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

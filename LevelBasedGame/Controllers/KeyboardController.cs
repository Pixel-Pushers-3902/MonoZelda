using LevelBasedGame.Commands;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Numerics;

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
            if (keyboardState.IsKeyDown(Keys.W))
            {
                // Player move forward command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(1, 0));
                newState = playerMoveCommand.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                // Player move backward command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(-1, 0));
                newState = playerMoveCommand.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                // Player move right command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(0, 1));
                newState = playerMoveCommand.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                // Player move left command
                ICommand playerMoveCommand = new PlayerMoveCommand(this, new Vector2(0, -1));
                newState = playerMoveCommand.Execute();
            }

            // Check for Player attack input
            if (keyboardState.IsKeyDown(Keys.Z))
            {
                // Player primary attack
                ICommand playerAttackCommand = new PlayerAttackCommand(this, 1);
                newState = playerAttackCommand.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.N))
            {
                // Player primary attack
                ICommand playerAttackCommand = new PlayerAttackCommand(this, 2);
                newState = playerAttackCommand.Execute();
            }

            // Check for Player damage applied
            if (keyboardState.IsKeyDown(Keys.E))
            {
                ICommand playerTakeDamageCommand = new PlayerTakeDamageCommand(this, 10);
                newState = playerTakeDamageCommand.Execute();
            }

            // Check for Block / Obstacle cycle input
            if (keyboardState.IsKeyDown(Keys.Y))
            {
                ICommand blockCycleCommand = new BlockCycleCommand(this, 1);
                newState = blockCycleCommand.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.T))
            {
                ICommand blockCycleCommand = new BlockCycleCommand(this, -1);
                newState = blockCycleCommand.Execute();
            }

            // Check for Item cycle input
            if (keyboardState.IsKeyDown(Keys.I))
            {
                ICommand itemCycleCommand = new ItemCycleCommand(this, 1);
                newState = itemCycleCommand.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.U))
            {
                ICommand itemCycleCommand = new ItemCycleCommand(this, -1);
                newState = itemCycleCommand.Execute();
            }

            // Check for Enemy / NPC cycle input
            if (keyboardState.IsKeyDown(Keys.P))
            {
                ICommand enemyCycleCommand = new EnemyCycleCommand(this, 1);
                newState = enemyCycleCommand.Execute();
            }
            else if (keyboardState.IsKeyDown(Keys.O))
            {
                ICommand enemyCycleCommand = new EnemyCycleCommand(this, -1);
                newState = enemyCycleCommand.Execute();
            }
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

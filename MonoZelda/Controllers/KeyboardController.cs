using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Items;

namespace PixelPushers.MonoZelda.Controllers;

public class KeyboardController : IController
{
    private KeyboardState previousKeyboardState;
    private KeyboardState currentKeyboardState;
    private GameState gameState;
    private Item GameItems;
    private ItemList previousItem;

    public KeyboardController(Item items)
    {
        gameState = GameState.Start;
        GameItems = items;
        previousItem = ItemList.None;
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
                ICommand blockCycleCommand = new BlockCycleCommand(this, 1);
                newState = blockCycleCommand.Execute();
            }
            else if (OneShotPressed(Keys.T))
            {
                ICommand blockCycleCommand = new BlockCycleCommand(this, -1);
                newState = blockCycleCommand.Execute();
            }

            // Check for Item cycle input
            if (OneShotPressed(Keys.I))
            {
                // store value of previous item
                previousItem = GameItems.CurrentItem;

                // If statement to check whether the previous item was BluePotion, in which case
                // item needs to start from Compass again.
                if (previousItem == ItemList.BluePotion)
                {
                    ICommand itemCycleCommand = new ItemCycleCommand(this, -14, GameItems);
                    newState = itemCycleCommand.Execute();
                }
                else
                {
                    ICommand itemCycleCommand = new ItemCycleCommand(this, 1, GameItems);
                    newState = itemCycleCommand.Execute();
                }
                System.Diagnostics.Debug.WriteLine("Current Item is: " + (int)GameItems.CurrentItem);
            }
            else if (OneShotPressed(Keys.U))
            {
                // store value of previous item
                previousItem = GameItems.CurrentItem;

                // If statement to check whether the previous item was Compass, in which case
                // item needs to start from BluePotion again.
                if (previousItem == ItemList.Compass)
                {
                    ICommand itemCycleCommand = new ItemCycleCommand(this, 14, GameItems);
                    newState = itemCycleCommand.Execute();
                }
                else
                {
                    ICommand itemCycleCommand = new ItemCycleCommand(this, -1, GameItems);
                    newState = itemCycleCommand.Execute();
                }
                System.Diagnostics.Debug.WriteLine("Current Item is: " + (int)GameItems.CurrentItem);
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

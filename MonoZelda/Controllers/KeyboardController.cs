using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Link.Projectiles;
using System;
using System.Collections.Generic;

namespace PixelPushers.MonoZelda.Controllers;

public class KeyboardController : IController
{
    private KeyboardState previousKeyboardState;
    private KeyboardState currentKeyboardState;
    private GameState gameState;
    private CommandManager commandManager;
    private KeyManager keyManager;

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
        currentKeyboardState = Keyboard.GetState();
        GameState newState = gameState;
        keyManager = new KeyManager(commandManager);

        // Check for Start game 
        if (OneShotPressed(Keys.Enter))
        {
            newState = commandManager.Execute(CommandEnum.StartGameCommand,Keys.Enter);
        }

        // Set controller for all commands
        commandManager.SetController(this);

        // Iterate keyCommandDictionary to check input
        foreach (var keyCommandPair in keyManager.KeyCommandDictionary)
        {
            Tuple<Keys, OneShot> keyOneShot = keyCommandPair.Key;
            if (keyOneShot.Item2 == OneShot.NO && (currentKeyboardState.IsKeyDown(keyOneShot.Item1) || keyOneShot.Item1 == Keys.None))
            {
                keyCommandPair.Value.Execute(keyOneShot.Item1);
                break;
            }
            else if(keyOneShot.Item2 == OneShot.YES && OneShotPressed(keyOneShot.Item1))
            {
               keyCommandPair.Value.Execute(keyOneShot.Item1);
               break;
            }
        }

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


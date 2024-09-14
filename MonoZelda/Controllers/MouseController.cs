using Microsoft.Xna.Framework.Input;

namespace PixelPushers.MonoZelda.Controllers;

public class MouseController : IController
{

    private MouseState mouseState;
    private GameState gameState;

    public MouseController()
    {
        gameState = GameState.Start;
    }

    // Properties
    public MouseState MouseState
    {
        get
        {
            return mouseState;
        }
        set
        {
            mouseState = value;
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

        // Mouse input logic goes here

        // Setting new Game State of mouse controller if needed
        if (gameState != newState)
        {
            gameState = newState;
            return true;
        }
        return false;
    }

}
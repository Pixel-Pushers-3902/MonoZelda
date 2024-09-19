using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Sprites;
using MonoGame.Framework.Utilities.Deflate;
using System.Runtime.InteropServices;

namespace PixelPushers.MonoZelda;

public enum GameState
{
    Start,
    Reset,
    Quit,
}

public class MonoZeldaGame : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private KeyboardController keyboardController;
    private MouseController mouseController;
    private GameState currentState;

    SpriteDict playerSpriteDict1;
    SpriteDict playerSpriteDict2;
    SpriteDict playerSpriteDict3;

    public MonoZeldaGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        currentState = GameState.Start;
        keyboardController = new KeyboardController();
        mouseController = new MouseController();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        //create 3 sprite dicts that are drawn on top of each other to showcase the priority system
        string playerCSVFileName = "Content/Source Rect CSVs/Sprite Source Rects - Player.csv";
        playerSpriteDict1 = new(Content.Load<Texture2D>("Sprites/player"), playerCSVFileName, 1, new Point(100, 100));
        playerSpriteDict2 = new(Content.Load<Texture2D>("Sprites/player"), playerCSVFileName, 2, new Point(84, 116));
        playerSpriteDict2.SetSprite("boomerang_blue");
        playerSpriteDict3 = new(Content.Load<Texture2D>("Sprites/player"), playerCSVFileName, 0, new Point(116, 116));
        playerSpriteDict3.SetSprite("boomerang");
    }

    protected override void Update(GameTime gameTime)
    {
        // Keyboard controller update loop
        keyboardController.CurrentKeyboardState = Keyboard.GetState();
        if (keyboardController.Update())
        {
            if (keyboardController.GameState == GameState.Quit)
            {
                Exit();
            }
            else if (keyboardController.GameState == GameState.Reset)
            {
                // Reset Logic here
                Debug.WriteLine("Resetting to Start state");

                // Set keyboardController state to Start
                keyboardController.GameState = GameState.Start;
            }
            else
            {
                currentState = keyboardController.GameState;
                mouseController.GameState = currentState;
            }
        }

        // Mouse controller update loop
        mouseController.MouseState = Mouse.GetState();
        if (mouseController.Update())
        {
            if (mouseController.GameState == GameState.Quit)
            {
                Exit();
            }
            else if (mouseController.GameState == GameState.Reset)
            {
                // Reset Logic here
                Debug.WriteLine("Resetting to Start state");

                // Set mouseController state to Start
                mouseController.GameState = GameState.Start;
            }
            else
            {
                currentState = mouseController.GameState;
                keyboardController.GameState = currentState;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Sprite drawing based on state
        spriteBatch.Begin();

        //hardcoded keyboard controls because i don't know how the command system is supposed to be used lol
        if (keyboardController.CurrentKeyboardState.IsKeyDown(Keys.W))
        {
            playerSpriteDict1.SetSprite("whitesword_up");
        }
        if (keyboardController.CurrentKeyboardState.IsKeyDown(Keys.A))
        {
            playerSpriteDict1.SetSprite("whitesword_left");
        }
        if (keyboardController.CurrentKeyboardState.IsKeyDown(Keys.S))
        {
            playerSpriteDict1.SetSprite("whitesword_down");
        }
        if (keyboardController.CurrentKeyboardState.IsKeyDown(Keys.D))
        {
            playerSpriteDict1.SetSprite("whitesword_right");
        }

        //call to SpriteDrawer to draw all SpriteDicts
        SpriteDrawer.Draw(spriteBatch, gameTime);

        spriteBatch.End();
        
        base.Draw(gameTime);
    }
}

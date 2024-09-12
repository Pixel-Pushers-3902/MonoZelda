using LevelBasedGame.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

public enum GameState
{
    Start,
    Reset,
    Quit,
}

namespace LevelBasedGame
{

    public class LevelGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardController keyboardController;
        private MouseController mouseController;
        private GameState currentState;


        public LevelGame()
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
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}

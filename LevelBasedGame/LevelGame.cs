using LevelBasedGame.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

public enum GameState
{
    Start,
    Still,
    StillAnimated,
    Moving,
    MovingAnimated,
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
        private StillSprite stillSprite;
        private StillAnimatedSprite stillAnimatedSprite;
        private MovingSprite movingSprite;
        private MovingAnimatedSprite movingAnimatedSprite;
        private int frameClock;
        private SpriteFont basicFont;


        public LevelGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            currentState = GameState.Still;
            keyboardController = new KeyboardController();
            mouseController = new MouseController();
            frameClock = 10;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D texture = Content.Load<Texture2D>("Sprites/pvz_sprite");
            basicFont = Content.Load<SpriteFont>("Fonts/Basic");
            stillSprite = new StillSprite(texture, 6);
            stillAnimatedSprite = new StillAnimatedSprite(texture, 6, frameClock);
            movingSprite = new MovingSprite(texture, 6, 3);
            movingAnimatedSprite = new MovingAnimatedSprite(texture, 6, 3, frameClock);
        }

        protected override void Update(GameTime gameTime)
        {
            // Keyboord controller update loop
            keyboardController.KeyboardState = Keyboard.GetState();
            if (keyboardController.Update())
            {
                if (keyboardController.Quit)
                {
                    Exit();
                }
                else
                {
                    currentState = keyboardController.GameState;
                    mouseController.GameState = currentState;
                }
            }

            mouseController.MouseState = Mouse.GetState();
            if (mouseController.Update())
            {
                if (mouseController.Quit)
                {
                    Exit();
                }
                else
                {
                    currentState = mouseController.GameState;
                    keyboardController.GameState = currentState;
                }
            }

            // Sprite update code
            stillSprite.Update();
            stillAnimatedSprite.Update();
            movingSprite.Update();
            movingAnimatedSprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Sprite drawing based on state
            spriteBatch.Begin();
            if (currentState == GameState.Still)
            {
                stillSprite.Draw(spriteBatch, new Vector2(272, 112));
            }
            else if (currentState == GameState.StillAnimated)
            {
                stillAnimatedSprite.Draw(spriteBatch, new Vector2(272, 112));
            }
            else if (currentState == GameState.Moving)
            {
                movingSprite.Draw(spriteBatch, new Vector2(272 + movingSprite.Displacement, 112));
            }
            else if (currentState == GameState.MovingAnimated)
            {
                movingAnimatedSprite.Draw(spriteBatch, new Vector2(272 + movingAnimatedSprite.Displacement, 112));
            }
            spriteBatch.DrawString(basicFont, "Credits", new Vector2(20, 375), Color.Black);
            spriteBatch.DrawString(basicFont, "Program Made By: Robert Greenslade", new Vector2(20, 405), Color.Black);
            spriteBatch.DrawString(basicFont, "Sprites From: https://community.facer.io/", new Vector2(20, 435), Color.Black);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}

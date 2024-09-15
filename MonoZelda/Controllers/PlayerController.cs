using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda
{
    public class PlayerController
    {
        private KeyboardController keyboardController;
        private SpriteDict playerSpriteDict;

        // Player pos
        private Vector2 playerPosition;

        // Movement speed 
        private float playerSpeed = 2.0f;

        public PlayerController(KeyboardController keyboardController, SpriteDict playerSpriteDict)
        {
            this.keyboardController = keyboardController;
            this.playerSpriteDict = playerSpriteDict;

            // Initial Position
            playerPosition = new Vector2(100, 100);
        }

        public void Update()
        {
            KeyboardState currentKeyboardState = keyboardController.CurrentKeyboardState;

            // Update player movement and sprite based on keyboard input
            if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                playerPosition.Y -= playerSpeed;
                playerSpriteDict.SetSprite("walk_up");
            }
            else if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                playerPosition.Y += playerSpeed;
                playerSpriteDict.SetSprite("walk_down");
            }
            else if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                playerPosition.X -= playerSpeed;
                playerSpriteDict.SetSprite("walk_left");
            }
            else if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                playerPosition.X += playerSpeed;
                playerSpriteDict.SetSprite("walk_right");
            }
        }

        // Draw the player sprite at the current position
        public void Draw(SpriteBatch spriteBatch, GameTime GameTime)
        {
            playerSpriteDict.Draw(spriteBatch, GameTime);
        }
    }
}

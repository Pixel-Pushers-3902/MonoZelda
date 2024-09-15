using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Controllers;
using System.Reflection.Metadata;

namespace PixelPushers.MonoZelda
{
    public class PlayerController
    {
        private KeyboardController keyboardController;
        private SpriteDict playerSpriteDict;
        private PlayerStateMachine playerStateMachine;

        // Player pos
        private Vector2 playerPosition;

        // Movement speed 
        private float playerSpeed = 2.0f;

        public PlayerController(KeyboardController keyboardController, SpriteDict playerSpriteDict)
        {
            this.keyboardController = keyboardController;
            this.playerSpriteDict = playerSpriteDict;
            //set default state to standing right
            playerSpriteDict.SetSprite("standing_right");
            this.playerStateMachine = new PlayerStateMachine();

            // Initial Position
            playerPosition = new Vector2(100, 100);
        }

        public void Update()
        {
            KeyboardState currentKeyboardState = keyboardController.CurrentKeyboardState;
            HandleMovement(currentKeyboardState);
            HandlePlayerAttack(currentKeyboardState);            
        }

        public void HandleMovement(KeyboardState currentKeyboardState)
        {
            // Update player movement and sprite based on keyboard input
            if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                playerPosition.Y -= playerSpeed;
                playerSpriteDict.SetSprite("walk_up");
                playerStateMachine.ChangeDirection(PlayerStateMachine.Direction.Up);

            }
            else if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                playerPosition.Y += playerSpeed;
                playerSpriteDict.SetSprite("walk_down");
                playerStateMachine.ChangeDirection(PlayerStateMachine.Direction.Down);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                playerPosition.X -= playerSpeed;
                playerSpriteDict.SetSprite("walk_left");
                playerStateMachine.ChangeDirection(PlayerStateMachine.Direction.Left);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                playerPosition.X += playerSpeed;
                playerSpriteDict.SetSprite("walk_right");
                playerStateMachine.ChangeDirection(PlayerStateMachine.Direction.Right);
            }
            else
            {  
                if(playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Up)
                {
                    playerSpriteDict.SetSprite("standing_up");
                }
                else if(playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Down)
                {
                    playerSpriteDict.SetSprite("standing_down");
                }
                else if (playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Left)
                {
                    playerSpriteDict.SetSprite("standing_left");
                }
                else if (playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Right)
                {
                    playerSpriteDict.SetSprite("standing_right");
                }
            }
            playerSpriteDict.Position = playerPosition.ToPoint();

        }

        public void HandlePlayerAttack(KeyboardState currentKeyboardState)
        {
            if ((currentKeyboardState.IsKeyDown(Keys.Z) || currentKeyboardState.IsKeyDown(Keys.N)) && playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Up)
            {
                playerSpriteDict.SetSprite("woodensword_up");
            } 
            else if ((currentKeyboardState.IsKeyDown(Keys.Z) || currentKeyboardState.IsKeyDown(Keys.N)) && playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Down)
            {
                playerSpriteDict.SetSprite("woodensword_down");
            } 
            else if ((currentKeyboardState.IsKeyDown(Keys.Z) || currentKeyboardState.IsKeyDown(Keys.N)) && playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Right)
            {
                playerSpriteDict.SetSprite("woodensword_right");
            }
            else if ((currentKeyboardState.IsKeyDown(Keys.Z) || currentKeyboardState.IsKeyDown(Keys.N)) && playerStateMachine.CurrentDirection == PlayerStateMachine.Direction.Left)
            {
                playerSpriteDict.SetSprite("woodensword_left");
            }
            playerSpriteDict.Position = playerPosition.ToPoint();
        }


        

        // Draw the player sprite at the current position
        public void Draw(SpriteBatch spriteBatch, GameTime GameTime)
        {
            playerSpriteDict.Draw(spriteBatch, GameTime);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies.EnemyStateMachines
{
    public class KeeseStateMachine
    {
        public bool FacingUp { get; private set; } = true;
        public bool FacingLeft { get; private set; } = true;
        public bool IsAttacking { get; private set; } = true; //could make decorator

        private readonly SpriteDict keeseSpriteDict; //set once keese sprite dict is implemented;
        private Point position = new Point(100, 100);

        public KeeseStateMachine(SpriteDict keeseSpriteDict)
        {
            this.keeseSpriteDict = keeseSpriteDict;

            keeseSpriteDict.SetSprite("walk_right");
        }

        public void ChangeVertDirection()
        {
            FacingUp = !FacingUp;
        }

        public void ChangeHorDirection()
        {
            FacingLeft = !FacingLeft;
        }

        public static void Attack() //not used
        {
        }

        public void Update()
        {
            if (FacingLeft)
            {
                position.X += 2;
            }else
            {
                position.X -= 2;
            }

            if (FacingUp)
            {
                position.Y += 2;
            }
            else
            {
                position.Y -= 2;
            }

            keeseSpriteDict.Position = position;

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            keeseSpriteDict.Draw(spriteBatch, gameTime);
        }
    }
}

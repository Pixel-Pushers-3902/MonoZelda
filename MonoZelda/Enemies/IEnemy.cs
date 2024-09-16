using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies
{
    public interface IEnemy
    {
        public void ChangeVertDirection();

        public void ChangeHorDirection();

        public void Attack();

        public void Update();

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}

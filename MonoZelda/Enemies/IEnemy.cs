using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies
{
    public interface IEnemy
    {
        public void SetOgPos();

        public void ChangeDirection();

        public void Update(GameTime gameTime);
        
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace MonoZelda.Collision
{
    public class CollisionHitboxDrawer
    {
        private List<Collidable> collidables;
        private Texture2D _pixel;

        public CollisionHitboxDrawer()
        {
            collidables = new List<Collidable>();
        }

        // Add a new hitbox
        public void AddHitbox(Collidable collidable)
        {
            collidables.Add(collidable);

        }


        // Remove a hitbox
        public void RemoveHitbox(Collidable collidable)
        {
            collidables.Remove(collidable);
        }

        // Get all hitboxes
        public List<Collidable> GetHitboxes()
        {
            return collidables;
        }
        private void CreatePixel(GraphicsDevice graphicsDevice)
        {
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }
        // Draw all hitboxes
        public void Draw(SpriteBatch spriteBatch, Color color, int thickness = 1)
        {
            if (_pixel == null)
            {
                CreatePixel(spriteBatch.GraphicsDevice);
            }
            foreach (var collidable in collidables)
            {
                Rectangle Bounds = collidable.Bounds;
                spriteBatch.Draw(_pixel, new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width, thickness), color);
                spriteBatch.Draw(_pixel, new Rectangle(Bounds.Left, Bounds.Bottom - thickness, Bounds.Width, thickness), color);
                spriteBatch.Draw(_pixel, new Rectangle(Bounds.Left, Bounds.Top, thickness, Bounds.Height), color);
                spriteBatch.Draw(_pixel, new Rectangle(Bounds.Right - thickness, Bounds.Top, thickness, Bounds.Height), color);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Link;
using System.Diagnostics;

namespace MonoZelda.Link
{
    public class PlayerCollision
    {
        private Rectangle boundingBox;
        private readonly int width;
        private readonly int height;
        private Player player;
        private Vector2 playerPosition;


        public PlayerCollision(Vector2 initialPosition)
        {
            this.width = 16;
            this.height = 16;
            Update(initialPosition);
        }

        public void Update(Vector2 playerPosition)
        {
            boundingBox.X = (int)playerPosition.X - width / 2;
            boundingBox.Y = (int)playerPosition.Y - height / 2;

        }

        public Rectangle GetBoundingBox()
        {
            return boundingBox;
        }
        public bool Intersects(Rectangle otherBox)
        {
            return boundingBox.Intersects(otherBox);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoZelda.Collision
{
    public class Collidable : ICollidable
    {
        public Rectangle Bounds { get; set; }

        public Collidable(Rectangle bounds)
        {
            Bounds = bounds;
        }

        public bool Intersects(ICollidable other)
        {
            return Bounds.Intersects(other.Bounds);
        }

        public Rectangle GetIntersectionArea(ICollidable other)
        {
            return Rectangle.Intersect(Bounds, other.Bounds);
        }
    }
}

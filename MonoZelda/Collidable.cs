using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoZelda
{
    public class Collidable
    {
        public Rectangle Bounds { get; set; }

        public Collidable(Rectangle bounds)
        {
            Bounds = bounds;
        }

        public bool Intersects(Collidable other)
        {
            return Bounds.Intersects(other.Bounds);
        }

        public Rectangle GetIntersectionArea(Collidable other)
        {
            return Rectangle.Intersect(Bounds, other.Bounds);
        }
    }
}

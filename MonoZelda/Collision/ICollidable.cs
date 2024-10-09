using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoZelda.Collision
{
    public interface ICollidable
    {
        Rectangle Bounds { get; set; }

        bool Intersects(ICollidable other);
        Rectangle GetIntersectionArea(ICollidable other);
    }
}

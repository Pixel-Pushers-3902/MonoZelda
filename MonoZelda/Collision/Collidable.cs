using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoZelda.Collision
{
    public class Collidable : ICollidable
    {
        public Rectangle Bounds { get; set; }

        private readonly CollisionHitboxDraw hitbox;

        public Collidable(Rectangle bounds, GraphicsDevice graphicsDevice)
        {
            Bounds = bounds;
            hitbox = new CollisionHitboxDraw(this, graphicsDevice);
        }

        public bool Intersects(ICollidable other)
        {
            return Bounds.Intersects(other.Bounds);
        }

        public Rectangle GetIntersectionArea(ICollidable other)
        {
            return Rectangle.Intersect(Bounds, other.Bounds);
        }

        public void SetGizmoColor(Color color) {
            hitbox.GizmoColor = color;
        }

        public void SetGizmoThickness(int thickness) {
            hitbox.Thickness = thickness;
        }
    }
}

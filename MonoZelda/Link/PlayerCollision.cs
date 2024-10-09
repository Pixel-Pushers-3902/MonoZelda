using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZelda.Collision;
using PixelPushers.MonoZelda.Link;

namespace MonoZelda.Link
{
    public class PlayerCollision
    {
        private readonly int width;
        private readonly int height;
        private Player player;
        private Collidable playerHitbox;
        private CollisionHitboxDrawer collisionHitboxDrawer;
        public PlayerCollision(Player player, Collidable playerHitbox, CollisionHitboxDrawer collisionHitboxDrawer)
        {
            this.player = player;
            this.playerHitbox = playerHitbox;
            this.width = 64;
            this.height = 64;

            // Create initial hitbox for the player
            Vector2 playerPosition = player.getPlayerPosition();
            Rectangle bounds = new Rectangle(
                (int)playerPosition.X - width / 2,
                (int)playerPosition.Y - height / 2,
                width,
                height
            );
            this.collisionHitboxDrawer = collisionHitboxDrawer;

            playerHitbox.Bounds = bounds;
        }

        public void Update()
        {
            UpdateBoundingBox();
        }

        private void UpdateBoundingBox()
        {
            Vector2 playerPosition = player.getPlayerPosition();
            Rectangle newBounds = new Rectangle(
                (int)playerPosition.X - width / 2,
                (int)playerPosition.Y - height / 2,
                width,
                height
            );

            playerHitbox.Bounds = newBounds;

            //check for collision
            List<Collidable> allHitBoxes = collisionHitboxDrawer.GetHitboxes();
            foreach (var hitbox in allHitBoxes)
            {
                if (hitbox == playerHitbox)
                {
                    continue; 
                }
                if (playerHitbox.Intersects(hitbox))
                {
                    Debug.WriteLine("Collision");
                    break; // Exit the loop early if a collision is detected
                }
            }
        }
    }
}
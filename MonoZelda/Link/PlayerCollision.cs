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
        private CollidablesManager collidablesManager;
        public PlayerCollision(Player player, Collidable playerHitbox, CollidablesManager collisionHitboxDrawer)
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
            this.collidablesManager = collisionHitboxDrawer;

            playerHitbox.Bounds = bounds;
        }

        public void Update()
        {
            UpdateBoundingBox();
            CheckCollision();
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
        }

        private void CheckCollision() {
            bool collided = false;
            List<Collidable> allHitBoxes = collidablesManager.GetHitboxes();
            foreach (var hitbox in allHitBoxes) {
                //ignore player's own hitbox
                if (hitbox == playerHitbox)
                    continue;
                //collision has occurred
                if (playerHitbox.Intersects(hitbox)) {
                    collided = true;
                    playerHitbox.SetGizmoColor(Color.Lime);
                    hitbox.SetGizmoColor(Color.Lime);
                }
                else {
                    //reset other collider's hitbox color
                    hitbox.SetGizmoColor(Color.Red);
                }
            }
            //collided with nothing
            if (!collided) {
                playerHitbox.SetGizmoColor(Color.Red);
            }
        }
    }
}
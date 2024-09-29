using Microsoft.Xna.Framework;

namespace MonoZelda.Enemies
{
    public interface IEnemy
    {
        public void SetOgPos(GameTime gameTime);

        public void DisableProjectile();

        public void ChangeDirection();

        public void Update(GameTime gameTime);
        
    }
}

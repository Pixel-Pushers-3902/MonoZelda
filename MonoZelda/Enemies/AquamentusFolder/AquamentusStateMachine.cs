using Microsoft.Xna.Framework;

namespace MonoZelda.Enemies.AquamentusFolder
{
    public class AquamentusStateMachine
    {
        private bool movingLeft = true;

        public void ChangeDirection()
        {
            movingLeft = !movingLeft;
        }

        public Point Update(Point position)
        {
            if(movingLeft)
            {
                position.X -= 1;
            }
            else
            {
                position.X += 1;
            }
            return position;
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies.AquamentusFolder
{
    public class AquamentusStateMachine
    {
        private bool movingLeft = true;

        private bool IsAttacking = false;

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

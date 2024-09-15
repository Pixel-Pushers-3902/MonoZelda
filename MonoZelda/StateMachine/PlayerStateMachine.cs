using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda
{
    public class PlayerStateMachine
    {
        public enum Direction { Up, Down, Left, Right, None }
        public Direction CurrentDirection { get; private set; } = Direction.None;
        public bool IsAttacking { get; private set; } = false;

        public void ChangeDirection(Direction newDirection)
        {
            CurrentDirection = newDirection;
        }
    }
}
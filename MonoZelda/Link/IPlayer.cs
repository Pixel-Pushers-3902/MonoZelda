using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Sprites;
using Microsoft.Xna.Framework;

namespace PixelPushers.MonoZelda.Link
{
    public interface IPlayer
    {
        void SetPlayerSpriteDict(SpriteDict spriteDict);
        void MovePlayer(PlayerMoveCommand moveCommand);
        void StandingPlayer(PlayerStandingCommand standCommand);
        Vector2 getPlayerPosition();
        Direction PlayerDirection { get; }
    }
}

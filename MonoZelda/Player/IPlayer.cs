using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Player
{
    public interface IPlayer
    {
        void SetPlayerSpriteDict(SpriteDict spriteDict);
        void MovePlayer(PlayerMoveCommand moveCommand);
        void StandingPlayer(PlayerStandingCommand standCommand);
        Direction PlayerDirection { get; }
    }
}

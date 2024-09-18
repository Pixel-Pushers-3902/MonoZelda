using PixelPushers.MonoZelda.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPushers.MonoZelda.Commands
{
    internal class PreviousTileCommand : ICommand
    {
        private ICycleable _tile;

        public PreviousTileCommand(ICycleable tile)
        {
            _tile = tile;
        }

        public GameState Execute()
        {
            _tile.Previous();

            // Returning a game state is weird
            return GameState.Start;
        }

        public GameState UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}

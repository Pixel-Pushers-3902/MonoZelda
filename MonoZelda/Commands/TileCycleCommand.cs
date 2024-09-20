using PixelPushers.MonoZelda.Tiles;

namespace PixelPushers.MonoZelda.Commands
{
    class TileCycleCommand : ICommand
    {
        private ICycleable _tile;

        public TileCycleCommand(ICycleable tile) 
        {
            _tile = tile;
        }

        public GameState Execute()
        {
            _tile.Next();

            // Returning a game state is weird
            return GameState.Start;
        }

        public GameState UnExecute()
        {
            _tile.Previous();

            return GameState.Start;
        }
    }
}

using System;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.PlayersNameSpace;

namespace PixelPushers.MonoZelda.Commands
{
    public class PlayerStandingCommand : ICommand
    {
        private IController controller;
        private Player player;
        private Direction lastDirection;

        public PlayerStandingCommand(IController controller, Player player)
        {
            this.controller = controller;
            this.player = player;
            this.lastDirection = player.PlayerDirection; // Assuming Player has a CurrentDirection property
        }

        public GameState Execute()
        {

            player.StandingPlayer(this);
            return controller.GameState;
        }

        public GameState UnExecute()
        {
            // Implement if you need to reverse this command
            throw new NotImplementedException();
        }

        public Direction PlayerDirection
        {
            get { return lastDirection; }
        }

       

       
    }
}

using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using PixelPushers.MonoZelda.Link;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands
{
    public class PlayerStandingCommand : ICommand
    {
        private IController controller;
        private Player player;
        private Direction lastDirection;

        public PlayerStandingCommand()
        {
            
        }

        public PlayerStandingCommand(Player player)
        {
            this.player = player;   
        }

        public GameState Execute()
        {
            if (player != null)
            {
                lastDirection = player.PlayerDirection; 
                player.StandingPlayer(this);
            }

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
        public void SetController(IController controller)
        {
            this.controller = controller;
        }  
    }
}

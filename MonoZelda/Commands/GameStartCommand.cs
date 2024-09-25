using System;
using System.Diagnostics;
using MonoZelda.Player;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class GameStartCommand : ICommand
{
    private IController _controller;

    public GameStartCommand()
    {

    }

    public GameState Execute()
    {
        // TODO: Anti-pattern. Should be like _game.Start();
        return GameState.Start;
    }

    public void SetController(IController controller)
    {
        _controller = controller;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

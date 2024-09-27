using System;
using System.Diagnostics;
using MonoZelda.Player;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Scenes;

namespace PixelPushers.MonoZelda.Commands;

public class ResetCommand : ICommand
{
    private IController _controller;
    private MonoZeldaGame _game;

    public ResetCommand()
    {
    }

    public ResetCommand(MonoZeldaGame game)
    {
        _game = game;
    }

    public GameState Execute()
    {
        _game?.StartMenu();

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

using System;
using PixelPushers.MonoZelda.Controllers;

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

using PixelPushers.MonoZelda.Controllers;
using System;

namespace PixelPushers.MonoZelda.Commands;

public class StartGameCommand : ICommand
{
    private IController _controller;
    private MonoZeldaGame _game;

    public StartGameCommand()
    {

    }

    public StartGameCommand(MonoZeldaGame game)
    {
        _game = game;
    }

    public GameState Execute()
    {
        _game?.StartDungeon();

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

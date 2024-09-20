using System;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class ExitCommand : ICommand
{
    IController controller;
    public ExitCommand()
    {
    }

    public GameState Execute()
    {
        return GameState.Quit;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }
}

using System;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class ExitCommand : ICommand
{
    IController controller;
    public ExitCommand(IController controller)
    {
        this.controller = controller;
    }

    public GameState Execute()
    {
        return GameState.Quit;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

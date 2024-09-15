using System;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public class ResetCommand : ICommand
{
    IController controller;
    public ResetCommand(IController controller)
    {
        this.controller = controller;
    }

    public GameState Execute()
    {
        return GameState.Reset;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

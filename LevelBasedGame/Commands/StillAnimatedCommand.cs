using System;
using System.Diagnostics;

namespace LevelBasedGame.Commands;
public class StillAnimatedCommand : ICommand
{
    IController controller;
    public StillAnimatedCommand(IController controller)
    {
        this.controller = controller;
    }

    public GameState Execute()
    {
        return GameState.StillAnimated;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

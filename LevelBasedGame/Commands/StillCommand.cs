using System;
using System.Diagnostics;

namespace LevelBasedGame.Commands;
public class StillCommand : ICommand
{
    IController controller;
    public StillCommand(IController controller)
    {
        this.controller = controller;
    }

    public GameState Execute()
    {
        return GameState.Still;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

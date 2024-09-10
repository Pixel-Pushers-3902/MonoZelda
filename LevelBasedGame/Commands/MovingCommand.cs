using System;
using System.Diagnostics;

namespace LevelBasedGame.Commands;
public class MovingCommand : ICommand
{
    IController controller;
    public MovingCommand(IController controller)
    {
        this.controller = controller;
    }

    public GameState Execute()
    {
        return GameState.Moving;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

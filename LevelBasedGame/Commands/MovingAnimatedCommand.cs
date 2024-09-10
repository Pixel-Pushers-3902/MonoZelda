using System;
using System.Diagnostics;

namespace LevelBasedGame.Commands;
public class MovingAnimatedCommand : ICommand
{
    IController controller;
    public MovingAnimatedCommand(IController controller)
    {
        this.controller = controller;
    }

    public GameState Execute()
    {
        return GameState.MovingAnimated;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}
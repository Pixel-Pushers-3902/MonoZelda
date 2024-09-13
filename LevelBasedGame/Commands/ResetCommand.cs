using System;

namespace LevelBasedGame.Commands;
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

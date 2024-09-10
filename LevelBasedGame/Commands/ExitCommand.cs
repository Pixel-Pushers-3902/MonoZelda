using System;

namespace LevelBasedGame.Commands;
public class ExitCommand : ICommand
{
    IController controller;
    public ExitCommand(IController controller)
    {
        this.controller = controller;
    }

    public GameState Execute()
    {
        controller.Quit = true;
        return GameState.Still;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

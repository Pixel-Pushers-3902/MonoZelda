using System;
using System.Diagnostics;
using System.Numerics;

namespace LevelBasedGame.Commands;
public class EnemyCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    public EnemyCycleCommand(IController controller, int cycleAddition)
    {
        this.controller = controller;
        this.cycleAddition = cycleAddition;
    }

    public GameState Execute()
    {
        // Apply cycle addition to enemy list
        Debug.WriteLine("Enemy list cycling by " + cycleAddition);

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Diagnostics;
using System.Numerics;

namespace LevelBasedGame.Commands;
public class PlayerMoveCommand : ICommand
{
    IController controller;
    Vector2 scalarVector;
    public PlayerMoveCommand(IController controller, Vector2 scalarVector)
    {
        this.controller = controller;
        this.scalarVector = scalarVector;
    }

    public GameState Execute()
    {
        // Apply movement to player
        Debug.WriteLine("Applying scalar vector " + scalarVector + " to player");

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

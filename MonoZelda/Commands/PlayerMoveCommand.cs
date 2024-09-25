using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using MonoZelda.Player;
using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
public class PlayerMoveCommand : ICommand
{
    private IController controller;
    private Vector2 scalarVector;
    private Direction playerDirection;
    private Player player; // Player reference

    public PlayerMoveCommand()
    {

    }

    public PlayerMoveCommand(Player player)
    {
    
        this.player = player; // Initialize player reference
        SetPlayerDirection();
        
    }

    private void SetPlayerDirection()
    {
        if (scalarVector.X > 0)
            playerDirection = Direction.Right;
        else if (scalarVector.X < 0)
            playerDirection = Direction.Left;
        else if (scalarVector.Y > 0)
            playerDirection = Direction.Down;
        else if (scalarVector.Y < 0)
            playerDirection = Direction.Up;
    }
    

    public GameState Execute()
    {
        // Update the player's direction
        player.MovePlayer(this);

        // Keep GameState the same inside the controller
        return controller.GameState;
    }
    public GameState UnExecute()
    {
        // Implement if you need to reverse this command
        throw new NotImplementedException();
    }

    public void SetScalarVector(Vector2 scalarVector)
    {
        this.scalarVector = scalarVector;
        SetPlayerDirection();
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }

    public Direction PlayerDirection
    {
        get { return playerDirection; }
    }
    public Vector2 PlayerVector
        { get { return scalarVector; } }
   
}

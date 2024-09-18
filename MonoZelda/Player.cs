using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Sprites;
using System.Diagnostics;
using Microsoft.Xna.Framework;



namespace PixelPushers.MonoZelda.PlayersNameSpace;

public class Player
{
    private Direction playerDirection;
    private SpriteDict playerSpriteDict;
    private Vector2 playerPostition;
    private float playerSpeed = 3.0f;
    public Player()
    {
        playerPostition = new Vector2(100, 100);

    }

    public void SetPlayerSpriteDict(SpriteDict spriteDict)
    {
        playerSpriteDict = spriteDict;
    }

    public void MovePlayer(PlayerMoveCommand moveCommand)
    {
        // Get and print the player's direction
        playerDirection = moveCommand.PlayerDirection;
        
        Debug.WriteLine($"Player is moving in the {playerDirection} direction.");
        //update player position
        playerPostition += playerSpeed * moveCommand.PlayerVector;

        // Set the player's sprite based on the direction
        SetMovingPlayerSprite(moveCommand);

    }
    public void StandingPlayer(PlayerStandingCommand standCommand)
    {
        playerDirection = standCommand.PlayerDirection;
        SetStandingPlayerSprite(standCommand);
    }
    private void SetStandingPlayerSprite(PlayerStandingCommand standCommand)
    {
        if (playerSpriteDict == null)
        {
            Debug.WriteLine("Warning: playerSpriteDict is not set.");
            return;
        }
        switch (playerDirection)
        {
            case Direction.Up:
                playerSpriteDict.SetSprite("standing_up");
                break;
            case Direction.Down:
                playerSpriteDict.SetSprite("standing_down");
                break;
            case Direction.Left:
                playerSpriteDict.SetSprite("standing_left");
                break;
            case Direction.Right:
                playerSpriteDict.SetSprite("standing_right");
                break;
        }



        playerSpriteDict.Position = this.playerPostition.ToPoint();
    }



    private void SetMovingPlayerSprite(PlayerMoveCommand moveCommand)
    {
        if (playerSpriteDict == null)
        {
            Debug.WriteLine("Warning: playerSpriteDict is not set.");
            return;
        }
        switch (playerDirection)
        {
            case Direction.Up:
                playerSpriteDict.SetSprite("walk_up");
                break;
            case Direction.Down:
                playerSpriteDict.SetSprite("walk_down");
                break;
            case Direction.Left:
                playerSpriteDict.SetSprite("walk_left");
                break;
            case Direction.Right:
                playerSpriteDict.SetSprite("walk_right");
                break;
        }
    
        
        
        playerSpriteDict.Position = this.playerPostition.ToPoint();
    }
    public Direction PlayerDirection
    {
        get { return playerDirection; }
    }

}
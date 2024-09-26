using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Sprites;
using System.Diagnostics;
using Microsoft.Xna.Framework;



namespace MonoZelda.Player;

public class Player : IPlayer
{
    private Direction playerDirection;
    private SpriteDict playerSpriteDict;
    private Vector2 playerPostition;
    private float playerSpeed = 4.0f;
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
        
        playerDirection = moveCommand.PlayerDirection;
        Debug.WriteLine($"Player is moving in the {playerDirection} direction.");
        playerPostition += playerSpeed * moveCommand.PlayerVector;
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
        playerSpriteDict.Position = playerPostition.ToPoint();

    }
    public void StandingPlayer(PlayerStandingCommand standCommand)
    {
        playerDirection = standCommand.PlayerDirection;
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



        playerSpriteDict.Position = playerPostition.ToPoint();
    }

    public void AttackingPlayer()
    {
        Debug.WriteLine("HES ATTACKING");
        switch (playerDirection)
        {
            case Direction.Up:
                playerSpriteDict.SetSprite("woodensword_up");
                break;
            case Direction.Down:
                playerSpriteDict.SetSprite("woodensword_down");
                break;
            case Direction.Left:
                playerSpriteDict.SetSprite("woodensword_left");
                break;
            case Direction.Right:
                playerSpriteDict.SetSprite("woodensword_right");
                break;
        }
    }

    public void PlayerUseItem()
    {
        Debug.WriteLine("Use ITEM");
        switch (playerDirection)
        {
            case Direction.Up:
                playerSpriteDict.SetSprite("useitem_up");
                break;
            case Direction.Down:
                playerSpriteDict.SetSprite("useitem_down");
                break;
            case Direction.Left:
                playerSpriteDict.SetSprite("useitem_left");
                break;
            case Direction.Right:
                playerSpriteDict.SetSprite("useitem_right");
                break;
        }
    }


    public void PlayerTakeDamage()
    {
        Debug.WriteLine("Use take damage");
        switch (playerDirection)
        {
            case Direction.Up:
                playerSpriteDict.SetSprite("magicshield_up");
                break;
            case Direction.Down:
                playerSpriteDict.SetSprite("magicshield_down");
                break;
            case Direction.Left:
                playerSpriteDict.SetSprite("magicshield_left");
                break;
            case Direction.Right:
                playerSpriteDict.SetSprite("magicshield_right");
                break;
        }
    }

    public Direction PlayerDirection
    {
        get { return playerDirection; }
    }

}
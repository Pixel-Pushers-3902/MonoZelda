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
    private int frames;
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
        if(frames == 0)
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
        else
        {
            frames--;
        }
        

    }
    public void StandingPlayer(PlayerStandingCommand standCommand)
    {
        
        if(frames == 0)
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
        }
        else
        {
            frames--;
        }
        



        playerSpriteDict.Position = playerPostition.ToPoint();
    }

    public void AttackingPlayer()
    {
        if (frames == 0)
        {
            Debug.WriteLine("HES ATTACKING");
            frames = 20;
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
        else
        {
            frames--;
        }
        
    }

    public void PlayerUseItem()
    {

        if(frames == 0)
        {
            Debug.WriteLine("Use ITEM");
            frames = 20;
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
        else
        {
            frames--;
        }
        
    }


    public void PlayerTakeDamage()
    {
        if (frames == 0)
        {
            frames = 20;
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
        else
        {
            frames--;
        }
        
    }

    public Direction PlayerDirection
    {
        get { return playerDirection; }
    }

    public int Frames
    {
        get { return frames; }
    }

}
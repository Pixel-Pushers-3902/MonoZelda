using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Commands;
using Microsoft.Xna.Framework;

namespace PixelPushers.MonoZelda.Link.Projectiles;

public class Boomerang : Projectile, ILaunch
{
    private bool Finished;
    private Vector2 InitialPosition;
    private SpriteDict projectileDict;
    private Player player;
    private float projectileSpeed = 4f;
    private int tilesTraveled;
    private Vector2 Dimension = new Vector2(8, 8);

    public Boomerang(SpriteDict projectileDict, Player player) : base(projectileDict, player)
    {
        this.projectileDict = projectileDict;
        this.player = player;
        Finished = false;
        SetProjectileSprite("boomerang");
        tilesTraveled = 0;
        InitialPosition = SetInitialPosition(Dimension);
    }

    public void Launch()
    {
        if (tilesTraveled < 3)
        {
            Forward();
        }
        else if (tilesTraveled >= 3 && tilesTraveled < 6)
        {
            Reverse();
        }
        else
        {
            Finished = reachedDistance();
            projectileDict.Enabled = false;
        }
        projectileDict.Position = projectilePosition.ToPoint();
    }

    private void Forward()
    {
        switch (playerDirection)
        {
            case Direction.Up:
                projectilePosition += projectileSpeed * (new Vector2(0, -1));
                break;
            case Direction.Down:
                projectilePosition += projectileSpeed * (new Vector2(0, 1));
                break;
            case Direction.Left:
                projectilePosition += projectileSpeed * (new Vector2(-1, 0));
                break;
            case Direction.Right:
                projectilePosition += projectileSpeed * (new Vector2(1, 0));
                break;
        }
        updateTilesTraveled();
    }

    private void Reverse()
    {
        switch (playerDirection)
        {
            case Direction.Up:
                projectilePosition -= projectileSpeed * (new Vector2(0, -1));
                break;
            case Direction.Down:
                projectilePosition -= projectileSpeed * (new Vector2(0, 1));
                break;
            case Direction.Left:
                projectilePosition -= projectileSpeed * (new Vector2(-1, 0));
                break;
            case Direction.Right:
                projectilePosition -= projectileSpeed * (new Vector2(1, 0));
                break;
        }
        updateTilesTraveled();
    }

    private void updateTilesTraveled()
    {
        double tolerance = 0.000001;
        if (Math.Abs(CalculateDistance(InitialPosition) - 64f) < tolerance)
        {
            tilesTraveled++;
            InitialPosition = projectilePosition;
        }
    }

    public bool reachedDistance()
    {
        bool reachedDistance = false;
        if(tilesTraveled == 6)
        {
            reachedDistance = true;
        }

        return reachedDistance;
    }

    public bool hasFinished()
    {
        return Finished;
    }
}

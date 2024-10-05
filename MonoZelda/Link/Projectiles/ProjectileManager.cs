using PixelPushers.MonoZelda.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PixelPushers.MonoZelda.Link.Projectiles;

public class ProjectileManager
{
    private Dictionary<ProjectileType, bool> projectileStates;
    private List<PlayerUseItemCommand> activeProjectiles;
    public ProjectileManager() 
    {
        projectileStates = new Dictionary<ProjectileType, bool>
        {
            {ProjectileType.arrow_green,false},
            {ProjectileType.arrow_blue,false},
            {ProjectileType.boomerang_green,false},
            {ProjectileType.boomerang_blue,false},
            {ProjectileType.bomb,false},
            {ProjectileType.candle_blue,false},
        };
        activeProjectiles = new List<PlayerUseItemCommand>();
    }
    

    public void AddProjectileToExecutionList(PlayerUseItemCommand firedProjectile)
    {
        activeProjectiles.Add(firedProjectile);
        projectileStates[firedProjectile.Projectile] = true;
    }

    public void ExecuteProjectileList() 
    {
        for(int i = 0; i < activeProjectiles.Count;i++)
        {
            PlayerUseItemCommand projectileFired = activeProjectiles[i];
            projectileFired.Execute();
            if (projectileFired.getProjectileState() == true)
            {
                projectileStates[projectileFired.Projectile] = false;
                activeProjectiles.Remove(projectileFired);
            }
        }
    }

    public bool GreenArrowLaunched()
    {
        return projectileStates[ProjectileType.arrow_green];
    }

    public bool BlueArrowLaunched()
    {
        return projectileStates[ProjectileType.arrow_blue];
    }

    public bool GreenBoomerangLaunched()
    {
        return projectileStates[ProjectileType.boomerang_green];
    }

    public bool BlueBoomerangLaunched()
    {
        return projectileStates[ProjectileType.boomerang_blue];
    }

    public bool BombLaunched()
    {
        return projectileStates[ProjectileType.bomb];
    }

    public bool FireLaunched()
    {
        return projectileStates[ProjectileType.candle_blue];
    }
}

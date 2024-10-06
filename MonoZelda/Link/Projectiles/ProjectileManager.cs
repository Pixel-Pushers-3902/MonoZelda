using PixelPushers.MonoZelda.Commands;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace PixelPushers.MonoZelda.Link.Projectiles;

public class ProjectileManager
{
    private bool projectileFired;
    private IProjectile itemFired;
    
    public bool ProjectileFired
    {
        get
        {
            return projectileFired;
        }
        set
        {
            projectileFired = value;
        }
    }

    public ProjectileManager() 
    {
        projectileFired = false;
    }
    
    public void setProjectile(IProjectile projectile)
    {
        itemFired = projectile;
        projectileFired = true;
    }

    public void executeProjectile()
    {
        if(itemFired != null)
        {
            if (!itemFired.hasFinished())
            {
                itemFired.updateProjectile();
            }
            else
            {
                projectileFired = false;
            }
        }
    }
}

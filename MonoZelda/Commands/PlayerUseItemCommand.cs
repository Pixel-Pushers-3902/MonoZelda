using System;
using System.Diagnostics;
using MonoZelda.Player;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Link.Projectiles;


namespace PixelPushers.MonoZelda.Commands;

public class PlayerUseItemCommand : ICommand
{
    IController controller;
    int itemIdx;
    Player player;  
    private IController controller;
    private int itemIdx;
    private Projectile projectiles;
    private ILaunch launchProjectile;
    private bool projectileFired;
    
    public PlayerUseItemCommand()
    {
    }

    public PlayerUseItemCommand(Projectile projectiles)
    {
        this.projectiles = projectiles;
    }

    public PlayerUseItemCommand(Player player)
    {
        this.player = player;
    }

    public GameState Execute()
    {
        // Swap player item idx to itemIdx
        launchProjectile.Launch();
        System.Diagnostics.Debug.WriteLine("Player is launching Projectile: " + projectiles.CurrentProjectile);

        Debug.WriteLine("Changing player item to " + itemIdx);
        player.PlayerUseItem();
        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }

    public void SetProjectile(int itemIdx)
    {
        projectiles.CurrentProjectile = (ProjectileType) itemIdx;
        launchProjectile = projectiles.GetProjectileObject();
        projectiles.enableDict();
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }

    public bool getProjectileState()
    {
        projectileFired = launchProjectile.hasFinished();
        if (projectileFired)
        {
            launchProjectile = null;
        }
        return projectileFired;
    }
}

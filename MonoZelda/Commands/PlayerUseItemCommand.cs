using System;
using PixelPushers.MonoZelda.Link;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Link.Projectiles;


namespace PixelPushers.MonoZelda.Commands;

public class PlayerUseItemCommand : ICommand
{
    private Player player;
    private IController controller;
    private Projectile projectiles;
    private IProjectile launchedProjectile;
    private ProjectileType projectileType;
    private int itemIdx;

    public PlayerUseItemCommand()
    {
    }

    public PlayerUseItemCommand(Projectile projectile, Player player)
    {
        this.projectiles = projectile;
        this.player = player;
    }

    public GameState Execute()
    {
        // animate player throw projectile
        if (player != null)
        {
            player.PlayerUseItem();
            launchedProjectile.updateProjectile();
        }

        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public void CreateProjectile(int itemNumber,ProjectileManager projectileManager)
    {
        launchedProjectile = projectiles.GetProjectileObject(itemNumber);
        projectileManager.setProjectile(launchedProjectile);
        projectiles.enableDict();
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }
}

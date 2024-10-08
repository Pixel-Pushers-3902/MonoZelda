﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoZelda.Enemies;
using PixelPushers.MonoZelda.Link;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Items;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Tiles;
using PixelPushers.MonoZelda.Link.Projectiles;
using MonoZelda.Link;
using MonoZelda.Collision;

namespace PixelPushers.MonoZelda.Scenes;

internal class DungeonScene : IScene
{
    private GraphicsDevice graphicsDevice;
    private CommandManager commandManager;
    private Player player;
    private PlayerCollision playerCollision;
    private EnemyCycler enemyCycler;
    CollisionHitboxDrawer collisionHitboxDrawer;
    public DungeonScene(GraphicsDevice device, GraphicsDeviceManager gManager, CommandManager cManager, MonoZeldaGame game, CollisionHitboxDrawer collisionHitboxManager) 
    {
        graphicsDevice = device;
        commandManager = cManager;
        player = new Player();
        this.collisionHitboxDrawer = collisionHitboxManager;
        Collidable playerHitbox = new Collidable(new Rectangle(100, 100, 50, 50));
        collisionHitboxDrawer.AddHitbox(playerHitbox);
        playerCollision = new PlayerCollision(player, playerHitbox, collisionHitboxDrawer);

        //create some sample hitboxes

        Collidable itemHitbox = new Collidable(new Rectangle(200, 200, 50, 50));
        collisionHitboxDrawer.AddHitbox(itemHitbox);

    }

    public void LoadContent(ContentManager contentManager)
    {
        var _ = new ExperimentalDungeonLoader(contentManager);

        // create projectile object and spriteDict
        var projectileDict = new SpriteDict(contentManager.Load<Texture2D>("Sprites/player"), SpriteCSVData.Projectiles, 0, new Point(0, 0));
        projectileDict.Enabled = false;
        var projectiles = new Projectile(projectileDict, player);




        // replace required commands
        commandManager.ReplaceCommand(CommandEnum.PlayerMoveCommand, new PlayerMoveCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerAttackCommand, new PlayerAttackCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerStandingCommand, new PlayerStandingCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerUseItemCommand, new PlayerUseItemCommand(projectiles,player));
        commandManager.ReplaceCommand(CommandEnum.PlayerTakeDamageCommand, new PlayerTakeDamageCommand(player));

        // create spritedict to pass into player controller
        var playerSpriteDict = new SpriteDict(contentManager.Load<Texture2D>(TextureData.Player), SpriteCSVData.Player, 1, new Point(100, 100));
        player.SetPlayerSpriteDict(playerSpriteDict);
    }

    public void Update(GameTime gameTime)
    {
        playerCollision.Update();
    }
}

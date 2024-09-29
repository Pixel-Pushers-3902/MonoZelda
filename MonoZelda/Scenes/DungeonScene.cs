using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoZelda.Enemies;
using PixelPushers.MonoZelda.Link;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Items;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Tiles;
using PixelPushers.MonoZelda.Link.Projectiles;

namespace PixelPushers.MonoZelda.Scenes;

internal class DungeonScene : IScene
{
    private GraphicsDevice graphicsDevice;
    private CommandManager commandManager;
    private Player player;

    private EnemyCycler enemyCycler;

    public DungeonScene(GraphicsDevice device, GraphicsDeviceManager gManager, CommandManager cManager, MonoZeldaGame game) 
    {
        graphicsDevice = device;
        commandManager = cManager;

        player = new Player();

        enemyCycler = new EnemyCycler(commandManager, gManager, game);
        var cycleCommand = new EnemyCycleCommand(enemyCycler);
        commandManager.ReplaceCommand(CommandEnum.EnemyCycleCommand, cycleCommand);
    }

    public void LoadContent(ContentManager contentManager)
    {
        // Setup TileDemo
        var tileDict = new SpriteDict(contentManager.Load<Texture2D>(TextureData.Blocks), SpriteCSVData.Blocks, 0, new Point(300, 300));
        var demoTile = new TileCycleDemo(tileDict, new Point(300, 300));

        //Setup ItemDemo
        var itemDict = new SpriteDict(contentManager.Load<Texture2D>(TextureData.Items), SpriteCSVData.Items, 0, new Point(450, 100));
        var demoItem = new ItemCycleDemo(itemDict, new Point(450, 100));

        // create projectile object and spriteDict
        var projectileDict = new SpriteDict(contentManager.Load<Texture2D>("Sprites/player"), SpriteCSVData.Projectiles, 0, new Point(0, 0));
        projectileDict.Enabled = false;
        var projectiles = new Projectile(projectileDict, player);

        // create the cycle commands
        commandManager.ReplaceCommand(CommandEnum.BlockCycleCommand, new BlockCycleCommand(demoTile));
        commandManager.ReplaceCommand(CommandEnum.ItemCycleCommand, new ItemCycleCommand(demoItem));
        commandManager.ReplaceCommand(CommandEnum.PlayerMoveCommand, new PlayerMoveCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerAttackCommand, new PlayerAttackCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerStandingCommand, new PlayerStandingCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerUseItemCommand, new PlayerUseItemCommand(projectiles,player));
        commandManager.ReplaceCommand(CommandEnum.PlayerTakeDamageCommand, new PlayerTakeDamageCommand(player));

        // create spritedict to pass into player controller
        var playerSpriteDict = new SpriteDict(contentManager.Load<Texture2D>(TextureData.Player), SpriteCSVData.Player, 1, new Point(100, 100));
        player.SetPlayerSpriteDict(playerSpriteDict);

        var enemySpriteDict = new SpriteDict(contentManager.Load<Texture2D>(TextureData.Enemies), SpriteCSVData.Enemies, 1, new Point(100, 100));
        enemyCycler.SetSpriteDicts(enemySpriteDict);
    }

    public void Update(GameTime gameTime)
    {
        enemyCycler.Update(gameTime);
    }

}

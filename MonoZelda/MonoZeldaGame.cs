using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Tiles;
using MonoZelda.Player;
using PixelPushers.MonoZelda.Items;


namespace PixelPushers.MonoZelda;

public enum GameState
{
    Start,
    Reset,
    Quit,
}

public class MonoZeldaGame : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private KeyboardController keyboardController;
    private MouseController mouseController;
    private CommandManager commandManager;
    private GameState currentState;
    private Player player;

    SpriteDict playerSpriteDict;
  

    public MonoZeldaGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        currentState = GameState.Start;
        player = new Player();
        commandManager = new CommandManager();

        keyboardController = new KeyboardController(commandManager, player);
        mouseController = new MouseController(commandManager);

    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // Setup TileDemo
        string blocksCSVFileName = "Content/Source Rect CSVs/Sprite Source Rects - Tiles Dungeon1.csv";
        var tileDict = new SpriteDict(Content.Load<Texture2D>("Sprites/tiles_dungeon1"), blocksCSVFileName, 0, new Point(300, 300));
        var demoTile = new TileCycleDemo(tileDict, new Point(300, 300));

        //Setup ItemDemo
        string itemsCSVFileName = "Content/Source Rect CSVs/Sprite Source Rects - Items.csv";
        var itemDict = new SpriteDict(Content.Load<Texture2D>("Sprites/items"), itemsCSVFileName, 0, new Point(450, 100));
        var demoItem = new ItemCycleDemo(itemDict, new Point(450, 100));

        // create the cycle commands
        commandManager.ReplaceCommand(CommandEnum.BlockCycleCommand, new BlockCycleCommand(demoTile));
        commandManager.ReplaceCommand(CommandEnum.ItemCycleCommand, new ItemCycleCommand(demoItem));
        commandManager.ReplaceCommand(CommandEnum.PlayerMoveCommand, new PlayerMoveCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerAttackCommand, new PlayerAttackCommand(player));
        commandManager.ReplaceCommand(CommandEnum.PlayerStandingCommand, new PlayerStandingCommand(player));
        //create spritedict to pass into player controller
        string playerCSVFileName = "Content/Source Rect CSVs/Sprite Source Rects - Player.csv";
        playerSpriteDict = new(Content.Load<Texture2D>("Sprites/player"), playerCSVFileName, 1, new Point(100, 100));
        player.SetPlayerSpriteDict(playerSpriteDict);
    }

    protected override void Update(GameTime gameTime)
    {
        // Keyboard controller update loop
        keyboardController.CurrentKeyboardState = Keyboard.GetState();
        if (keyboardController.Update())
        {
            if (keyboardController.GameState == GameState.Quit)
            {
                Exit();
            }
            else if (keyboardController.GameState == GameState.Reset)
            {
                // Reset Logic here
                Debug.WriteLine("Resetting to Start state");

                // Set keyboardController state to Start
                keyboardController.GameState = GameState.Start;
            }
            else
            {
                currentState = keyboardController.GameState;
                mouseController.GameState = currentState;
            }
        }

        // Mouse controller update loop
        mouseController.MouseState = Mouse.GetState();
        if (mouseController.Update())
        {
            if (mouseController.GameState == GameState.Quit)
            {
                Exit();
            }
            else if (mouseController.GameState == GameState.Reset)
            {
                // Reset Logic here
                Debug.WriteLine("Resetting to Start state");

                // Set mouseController state to Start
                mouseController.GameState = GameState.Start;
            }
            else
            {
                currentState = mouseController.GameState;
                keyboardController.GameState = currentState;
            }
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Sprite drawing based on state
        spriteBatch.Begin();

        // Draw player
        playerSpriteDict.Draw(spriteBatch, gameTime);

        //call to SpriteDrawer to draw all SpriteDicts
        SpriteDrawer.Draw(spriteBatch, gameTime);

        spriteBatch.End();
        
        base.Draw(gameTime);
    }
}

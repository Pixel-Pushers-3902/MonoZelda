using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonoZelda.Enemies;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Scenes;


namespace PixelPushers.MonoZelda;

public enum GameState
{
    Title,
    Start,
    Reset,
    Quit,
}

public class MonoZeldaGame : Game
{
    private GraphicsDeviceManager graphicsDeviceManager;
    private SpriteBatch spriteBatch;
    private KeyboardController keyboardController;
    private MouseController mouseController;
    private CommandManager commandManager;
    private GameState currentState;

    private IScene scene;

    public MonoZeldaGame()
    {
        graphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        currentState = GameState.Title;

        commandManager = new CommandManager();

        // Exit Command needs the game reference
        commandManager.ReplaceCommand(CommandEnum.ExitCommand, new ExitCommand(this));

        // Start game command
        commandManager.ReplaceCommand(CommandEnum.StartCommand, new StartGameCommand(this));
        commandManager.ReplaceCommand(CommandEnum.ResetCommand, new ResetCommand(this));

        keyboardController = new KeyboardController(commandManager);
        mouseController = new MouseController(commandManager);
    }

    protected override void Initialize()
    {
        graphicsDeviceManager.PreferredBackBufferWidth = 1024;
        graphicsDeviceManager.PreferredBackBufferHeight = 896;
        graphicsDeviceManager.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // Load the first scene
        StartMenu();
    }

    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update();
        mouseController.Update();

        scene.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Sprite drawing based on state
        spriteBatch.Begin();

        //call to SpriteDrawer to draw all SpriteDicts
        SpriteDrawer.Draw(spriteBatch, gameTime);

        spriteBatch.End();

        base.Draw(gameTime);
    }

    protected void LoadScene(IScene scene)
    {
        // Clean state to start a new scene
        SpriteDrawer.Reset();
        this.scene = scene;
        scene.LoadContent(Content);
    }

    public void StartMenu()
    {
        LoadScene(new MainMenu(GraphicsDevice));
    }

    public void StartDungeon()
    {
        // Preventing the StartCommand from activating when it shouldn't. -js
        if (scene is MainMenu)
        {
            LoadScene(new DungeonScene(GraphicsDevice, graphicsDeviceManager, commandManager));
        }
    }
}

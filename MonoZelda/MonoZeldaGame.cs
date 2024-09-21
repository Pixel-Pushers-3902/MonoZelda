using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonoZelda.Enemies;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Sprites;
using MonoGame.Framework.Utilities.Deflate;
using System.Runtime.InteropServices;
using MonoZelda.Controllers;
using PixelPushers.MonoZelda.Commands;

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
    private EnemyController enemyController;
    private GameState currentState;
    private IEnemy enemy;

    private SpriteDict enemySpriteDict;

    public MonoZeldaGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        currentState = GameState.Start;

        // Init Commands
        CommandManager commandManager = new CommandManager();
        keyboardController = new KeyboardController(commandManager);
        mouseController = new MouseController(commandManager);

        enemyController = new EnemyController(commandManager);
        EnemyCycleCommand enemyCycleCommand = (EnemyCycleCommand) commandManager.CommandMap[CommandEnum.EnemyCycleCommand];
        enemyCycleCommand.SetCycler(enemyController);


    }

    protected override void Initialize()
    {
        enemy = enemyController.Enemy;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        string enemyCsvFileName = "Content/Source Rect CSVs/Sprite Source Rects - Enemies.csv";
        enemySpriteDict = new(Content.Load<Texture2D>("Sprites/enemies"), enemyCsvFileName, 1, new Point(100, 100));
        enemyController.SetSpriteDicts(enemySpriteDict);
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

        enemyController.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Sprite drawing based on state
        spriteBatch.Begin();

        enemySpriteDict.Draw(spriteBatch, gameTime);

        spriteBatch.End();
        
        base.Draw(gameTime);
    }
}

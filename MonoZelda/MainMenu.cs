using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPushers.MonoZelda;

public class MainMenu : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private CommandManager commandManager;
    private MainMenuController _menuController;
    private SpriteFont _font;
    private Texture2D _titleTexture;

    public MainMenu()
    {
        commandManager = new CommandManager();
        _menuController = new MainMenuController(commandManager);

        // Exit Command needs the game reference
        commandManager.ReplaceCommand(CommandEnum.ExitCommand, new ExitCommand(this));

        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Load title content
        _titleTexture = Content.Load<Texture2D>("Sprites/title");
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        _menuController.Update();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // Sprite drawing based on state
        _spriteBatch.Begin();

        // Draw title screen as big as the screen
        var titleRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        var yMagin = GraphicsDevice.Viewport.Width / 2;
        var xMargin = GraphicsDevice.Viewport.Height / 2;
        _spriteBatch.Draw(_titleTexture, new Rectangle(yMagin - 256, xMargin - 224, 256 * 2, 224*2), new Rectangle(1,11,256,224), Color.White);

        //call to SpriteDrawer to draw all SpriteDicts
        SpriteDrawer.Draw(_spriteBatch, gameTime);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
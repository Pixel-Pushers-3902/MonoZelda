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

public class MainMenu
{
    Texture2D _titleTexture;
    GraphicsDevice _device;
    
    public MainMenu(Texture2D menuTexture, GraphicsDevice graphicsDevice)
    {
        _titleTexture = menuTexture;
        _device = graphicsDevice;
    }

    public void Draw(SpriteBatch batch, GameTime gameTime)
    {
        _device.Clear(Color.Black);

        // Sprite drawing based on state
        batch.Begin();

        // Draw title screen as big as the screen
        var titleRect = new Rectangle(0, 0, _device.Viewport.Width, _device.Viewport.Height);
        var yMagin = _device.Viewport.Width / 2;
        var xMargin = _device.Viewport.Height / 2;
        batch.Draw(_titleTexture, new Rectangle(yMagin - 256, xMargin - 224, 256 * 2, 224*2), new Rectangle(1,11,256,224), Color.White);

        batch.End();
    }
}
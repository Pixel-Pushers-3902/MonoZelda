using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StillSprite : ISprite
{
    private int currentFrame;
    private int totalFrames;
    public Texture2D Texture { get; set; }
    public int Columns { get; set; }

    public StillSprite(Texture2D texture, int columns)
    {
        Texture = texture;
        currentFrame = 0;
        Columns = columns;
        totalFrames = columns;
    }

    public void Update()
    {
        currentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        int width = Texture.Width / Columns;
        int height = Texture.Height;
        int column = currentFrame % Columns;

        Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
        Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

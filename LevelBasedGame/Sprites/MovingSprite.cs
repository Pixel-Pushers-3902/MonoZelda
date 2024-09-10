using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovingSprite : ISprite
{
    private int currentFrame;
    private int totalFrames;
    private int stepSize;
    private int maxDistance;

    public Texture2D Texture { get; set; }
    public int Columns { get; set; }
    public int Displacement { get; set; }

    public MovingSprite(Texture2D texture, int columns, int stepSize)
    {
        Texture = texture;
        Columns = columns;
        currentFrame = 0;
        totalFrames = columns;
        this.stepSize = stepSize;
        Displacement = 0;
        maxDistance = 100;
    }

    public void Update()
    {
        currentFrame = 0;
        if (Math.Abs(Displacement) > maxDistance)
        {
            stepSize = stepSize * -1;
        }
        Displacement += stepSize;

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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PixelPushers.MonoZelda.Sprites;

internal class SpriteDict
{
    public Point Position { get; set; }
    public bool Enabled { get; set; }

    private readonly Texture2D texture;
    private readonly Dictionary<string, Sprite> dict = new();
    private string currentSprite = "";

    public SpriteDict(Texture2D texture, string CSVname, int priority, Point position)
    {
        this.texture = texture;
        Position = position;
        SpriteSheetParser.Parse(this, CSVname);
        SpriteDrawer.RegisterSpriteDict(this, priority);
    }

    public void Add(Sprite sprite, string name)
    {
        dict.Add(name, sprite);

        //set current sprite to sprite being added if no sprite is currently set
        if (currentSprite == "")
        {
            currentSprite = name;
        }
    }

    public void SetSprite(string name)
    {
        currentSprite = name;
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        dict[currentSprite].Draw(spriteBatch, gameTime, texture, Position);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPushers.MonoZelda;

interface ISprite
{

    public Texture2D Texture { get; set; }
    public int Columns { get; set; }

    void Update();
    void Draw(SpriteBatch spriteBatch, Vector2 location);
}

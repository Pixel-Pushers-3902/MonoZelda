using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public interface IDrawable
{
	public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}

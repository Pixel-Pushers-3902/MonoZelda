using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PixelPushers.MonoZelda.Scenes;

public interface IScene
{
    void Update(GameTime gameTime);
    void LoadContent(ContentManager contentManager);
}

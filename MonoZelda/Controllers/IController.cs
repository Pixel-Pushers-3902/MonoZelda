using System;

namespace PixelPushers.MonoZelda.Controllers;

public interface IController
{
    // Properties
    GameState GameState { get; set; }

    // Methods
    Boolean Update();
}

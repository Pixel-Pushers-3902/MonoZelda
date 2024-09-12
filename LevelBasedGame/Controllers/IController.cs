using System;

public interface IController
{
    // Properties
    GameState GameState { get; set; }

    // Methods
    Boolean Update();
}

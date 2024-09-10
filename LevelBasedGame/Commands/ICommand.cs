using LevelBasedGame;
using System;

public interface ICommand
{
    GameState Execute();
    GameState UnExecute();
}

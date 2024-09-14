namespace PixelPushers.MonoZelda.Commands;

public interface ICommand
{
    GameState Execute();
    GameState UnExecute();
}

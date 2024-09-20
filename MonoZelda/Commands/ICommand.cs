using PixelPushers.MonoZelda.Controllers;

namespace PixelPushers.MonoZelda.Commands;

public interface ICommand
{
    GameState Execute();
    GameState UnExecute();
    void SetController(IController controller);
}

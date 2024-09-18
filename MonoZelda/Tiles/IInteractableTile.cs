
namespace PixelPushers.MonoZelda.Tiles;

internal interface IInteractiveTile : ITile
{
    // TODO: Refactor for Player type
    void Interact(Object player); // Defines behavior when player interacts
}


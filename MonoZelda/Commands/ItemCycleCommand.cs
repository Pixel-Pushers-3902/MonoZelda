using System;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Items;

namespace PixelPushers.MonoZelda.Commands;

public class ItemCycleCommand : ICommand
{
    IController controller;
    int cycleAddition;
    Item GameItems;

    public ItemCycleCommand()
    {
    }
    
    public GameState Execute()
    {
        // Update the currentItem based on the value of cycleAddition
        GameItems.CurrentItem = (ItemList)((int)GameItems.CurrentItem + cycleAddition);


        // Keep GameState the same inside the controller
        return controller.GameState;
    }

    public GameState UnExecute()
    {
        throw new NotImplementedException();
    }

    public void SetCycleAddition(int cycleAddition)
    {
        this.cycleAddition = cycleAddition;
    }

    public void SetController(IController controller)
    {
        this.controller = controller;
    }

    public void SetItemObject(Item GameItems)
    {
        this.GameItems = GameItems;
    }
}

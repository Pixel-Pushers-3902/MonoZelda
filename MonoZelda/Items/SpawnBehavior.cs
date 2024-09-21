using PixelPushers.MonoZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Items;

public class SpawnBehaviour : ISpawn
{
    private ISpawn Item;

    public SpawnBehaviour()
    {
        ISpawn item = null;
    }

    public void setSpawnBehaviour(ItemList currentItem)
    {
        // To-do (for future workings of game. Classes are not finalized)
    }

}

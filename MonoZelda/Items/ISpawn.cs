using PixelPushers.MonoZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Items;

public interface ISpawn
{
    void setSpawnBehaviour(ItemList item);
}

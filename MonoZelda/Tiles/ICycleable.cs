using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPushers.MonoZelda.Tiles
{
    public interface ICycleable
    {
        void Next();
        void Previous();
    }
}

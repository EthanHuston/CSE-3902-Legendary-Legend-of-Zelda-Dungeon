using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    interface ICollision
    {
        void HandleCollison<T, U>(T MainSpawnable, U SecondarySpawnable, Constants.Direction side);
    }
}

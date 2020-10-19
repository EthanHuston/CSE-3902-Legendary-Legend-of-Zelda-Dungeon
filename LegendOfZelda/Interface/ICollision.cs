using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ICollision<T, U>
    {
        void HandleCollison(T MainSpawnable, U SecondarySpawnable, Constants.Direction side);
    }
}

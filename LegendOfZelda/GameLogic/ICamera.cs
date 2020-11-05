using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.GameLogic
{
    interface ICamera<T, U>
    {
        void Pan(T currentFrame, U newFrame, Vector2 velocity, int distance);
        void Update();
        void Draw();
        void IsPanning();
    }
}

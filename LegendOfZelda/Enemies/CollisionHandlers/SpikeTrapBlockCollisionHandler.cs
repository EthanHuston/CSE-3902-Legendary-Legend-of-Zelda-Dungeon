using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Enemies.CollisionHandlers
{
    class SpikeTrapBlockCollisionHandler : ICollision
    {
        public void HandleCollison<INpc, IBlock>(INpc enemy, IBlock block, Constants.Direction side)
        {
        }
    }
}

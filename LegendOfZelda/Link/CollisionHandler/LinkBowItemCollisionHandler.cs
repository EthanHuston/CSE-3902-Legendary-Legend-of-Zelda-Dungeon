using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkBowItemCollisionHandler : ICollision
    {
        public void HandleCollison<IPlayer, IItem>(IPlayer link, IItem bow, Constants.Direction side)
        {

            // call methods to make link pick up bow
            // call methods to despawn bow
        }
    }
}

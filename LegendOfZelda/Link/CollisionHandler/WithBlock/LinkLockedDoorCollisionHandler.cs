using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    class LinkLockedDoorCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            IDoor door = (IDoor)block;
            if (door.IsOpen) return;
            if (link.GetQuantityInInventory(LinkConstants.ItemType.Key) > 0)
            {
                link.ConsumeKey();
                door.OpenDoor();
            }
            else
                new LinkImmovableBlockCollisionHandler().HandleCollision(link, block, side);
        }
    }
}

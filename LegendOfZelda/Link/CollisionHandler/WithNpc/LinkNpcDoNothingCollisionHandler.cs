using LegendOfZelda.Enemies;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler.WithNpc
{
    class LinkNpcDoNothingCollisionHandler : ICollisionHandler<IPlayer, INpc>
    {
        public void HandleCollision(IPlayer link, INpc npc, Constants.Direction side)
        {
        }
    }
}

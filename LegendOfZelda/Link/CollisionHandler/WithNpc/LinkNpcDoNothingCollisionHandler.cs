using LegendOfZelda.Enemies;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Link.CollisionHandler.WithNpc
{
    internal class LinkNpcDoNothingCollisionHandler : ICollisionHandler<IPlayer, INpc>
    {
        public void HandleCollision(IPlayer link, INpc npc, Constants.Direction side)
        {
        }
    }
}

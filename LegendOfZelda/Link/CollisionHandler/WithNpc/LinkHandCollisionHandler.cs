using LegendOfZelda.Enemies;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithNpc
{
    internal class LinkHandCollisionHandler : ICollisionHandler<IPlayer, INpc>
    {
        private const int dragTimeMs = 2000;

        public void HandleCollision(IPlayer link, INpc enemy, Constants.Direction side)
        {
            link.BeDamaged(enemy.GetDamageAmount());
            // TODO: fix dragging collisions
        }
    }
}

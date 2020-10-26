using LegendOfZelda.Enemies;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Link.CollisionHandler.WithNpc
{
    class LinkHandCollisionHandler : ICollisionHandler<IPlayer, INpc>
    {
        private const int dragTimeMs = 400;

        public void HandleCollision(IPlayer link, INpc enemy, Constants.Direction side)
        {
            link.BeDamaged(enemy.GetDamageAmount());
            link.Drag(enemy, dragTimeMs);
        }
    }
}

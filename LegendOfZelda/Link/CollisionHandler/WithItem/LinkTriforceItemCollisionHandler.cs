using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkTriforceItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem triforce, Constants.Direction side)
        {
            link.PickUpTriforce();
            triforce.Despawn();
        }
    }
}

using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    class BombDoorCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile projectile, IBlock block, Constants.Direction side)
        {
            if (typeof(BombableOpening) != block.GetType()) return;

            IDoor door = (IDoor)block;
            BombExplodingProjectile bomb = (BombExplodingProjectile)projectile;
            if (!door.IsOpen && bomb.IsExploded()) door.OpenDoor();
        }
    }
}

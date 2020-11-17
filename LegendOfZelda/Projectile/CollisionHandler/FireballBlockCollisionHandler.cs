using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using System;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class FireballBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile fireball, IBlock block, Constants.Direction side)
        {
            Type blockType = block.GetType();
            if (blockType == typeof(TileWater) || blockType == typeof(SecretRoomWall)) return;
            fireball.Despawn();
        }
    }
}

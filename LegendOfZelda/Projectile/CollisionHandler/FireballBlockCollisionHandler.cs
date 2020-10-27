﻿using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class FireballBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile fireball, IBlock block, Constants.Direction side)
        {
            if (block.GetType() == typeof(TileWater)) return;
            fireball.Despawn();
        }
    }
}

﻿using LegendOfZelda.GameLogic;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    internal class EnemySwordCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile sword, Constants.Direction side)
        {
            enemy.TakeDamage(sword.DamageAmount());
            if (enemy.GetType() == typeof(Skeleton) || enemy.GetType() == typeof(Goriya))
            {
                enemy.SetKnockBack(true, side);
            }
        }
    }
}

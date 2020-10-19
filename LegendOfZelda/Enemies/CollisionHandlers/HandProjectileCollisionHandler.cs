using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Enemies.CollisionHandlers
{
    class HandProjectileCollisionHandler : ICollision<INpc, IProjectile>
    {
        public void HandleCollison(INpc enemy, IProjectile projectile, Constants.Direction side)
        {
            enemy.TakeDamage(projectile.DamageAmount());

        }
    }
}

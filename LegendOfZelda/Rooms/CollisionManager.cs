using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.Link.CollisionHandler;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Rooms
{
    class CollisionManager : ICollisionManager
    {
        private ISpawnableManager spawnableManager;
        private CollisionHandlerDictionary handlerDictionary;

        public CollisionManager(ISpawnableManager spawnableManager)
        {
            this.spawnableManager = spawnableManager;

            handlerDictionary = new CollisionHandlerDictionary();
        }

        public void HandleAllCollisions()
        {
            CheckAndHandlePlayerCollisions();
            CheckAndHandleNpcCollisions();
            CheckAndHandleProjectileCollisions();
        }

        private void CheckAndHandlePlayerCollisions()
        {

            foreach (IPlayer player in spawnableManager.ItemList)
            {
                // iterate through Link vs. Npc
                foreach (INpc npc in spawnableManager.NpcList)
                {
                    CheckIntersectionAndHandle(player, npc);
                }
                // iterate through Link vs. Projectiles
                foreach (IProjectile projectile in spawnableManager.ProjectileList)
                {

                }
                // iterate through Link vs. Items
                foreach (IItem item in spawnableManager.ItemList)
                {

                }
                // iterate through Link vs. Blocks 
                foreach (IBlock block in spawnableManager.BlockList)
                {

                }
            }
        }

        private void CheckAndHandleNpcCollisions()
        {
            foreach (INpc npc in spawnableManager.NpcList)
            {
                // iterate through Npc vs. Projectiles
                foreach (IProjectile projectile in spawnableManager.ProjectileList)
                {

                }
                // iterate through Npc vs. Blocks
                foreach (IBlock block in spawnableManager.BlockList)
                {

                }
            }
        }

        private void CheckAndHandleProjectileCollisions()
        {
            foreach (IProjectile projectile in spawnableManager.ProjectileList)
            {
                foreach (IBlock block in spawnableManager.BlockList)
                {

                }
            }
        }

        private void CheckIntersectionAndHandle(IPlayer player, ISpawnable spawnable)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), spawnable.GetRectangle());
            if (!collisionFound.Equals(Rectangle.Empty))
            {
                Constants.Direction direction = UtilityMethods.GetCollisionDirection(player.GetRectangle(), spawnable.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerNpcHandler(spawnable.GetType());
            }
        }
    }
}

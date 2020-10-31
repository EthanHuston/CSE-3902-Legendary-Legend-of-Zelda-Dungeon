using LegendOfZelda.Enemies;
using LegendOfZelda.Environment;
using LegendOfZelda.Item;
using LegendOfZelda.Link;
using LegendOfZelda.Projectile;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameLogic
{
    internal class CollisionManager : ICollisionManager
    {
        private readonly ISpawnableManager spawnableManager;
        private readonly CollisionHandlerDictionary handlerDictionary;

        public CollisionManager(ISpawnableManager spawnableManager)
        {
            this.spawnableManager = spawnableManager;

            handlerDictionary = new CollisionHandlerDictionary();
        }

        public void CheckAndHandleAllCollisions()
        {
            CheckAndHandlePlayerCollisions();
            CheckAndHandleNpcCollisions();
            CheckAndHandleProjectileCollisions();
            // CheckAndHandlerItemCollisions();
        }

        private void CheckAndHandlePlayerCollisions()
        {
            foreach (IPlayer player in spawnableManager.PlayerList)
            {
                // iterate through Link vs. Npc
                foreach (INpc npc in spawnableManager.NpcList)
                {
                    CheckIntersectionAndHandleCollision(player, npc);
                }
                // iterate through Link vs. Projectiles
                foreach (IProjectile projectile in spawnableManager.ProjectileList)
                {
                    CheckIntersectionAndHandleCollision(player, projectile);
                }
                // iterate through Link vs. Items
                foreach (IItem item in spawnableManager.ItemList)
                {
                    CheckIntersectionAndHandleCollision(player, item);
                }
                // iterate through Link vs. Blocks 
                foreach (IBlock block in spawnableManager.BlockList)
                {
                    CheckIntersectionAndHandleCollision(player, block);
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
                    CheckIntersectionAndHandleCollision(npc, projectile);
                }
                // iterate through Npc vs. Blocks
                foreach (IBlock block in spawnableManager.BlockList)
                {
                    CheckIntersectionAndHandleCollision(npc, block);
                }
            }
        }

        private void CheckAndHandleProjectileCollisions()
        {
            foreach (IProjectile projectile in spawnableManager.ProjectileList)
            {
                foreach (IBlock block in spawnableManager.BlockList)
                {
                    CheckIntersectionAndHandleCollision(projectile, block);
                }
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, INpc npc)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), npc.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), npc.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerNpcHandler(npc.GetType()).HandleCollision(player, npc, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, IProjectile projectile)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), projectile.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), projectile.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerProjectileHandler(projectile.GetType()).HandleCollision(player, projectile, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, IItem item)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), item.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), item.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerItemHandler(item.GetType()).HandleCollision(player, item, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, IBlock block)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), block.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), block.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerBlockHandler(block.GetType()).HandleCollision(player, block, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(INpc npc, IProjectile projectile)
        {
            Rectangle collisionFound = Rectangle.Intersect(npc.GetRectangle(), projectile.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(npc.GetRectangle(), projectile.GetRectangle(), collisionFound);
                handlerDictionary.GetNpcProjectileHandler(projectile.GetType()).HandleCollision(npc, projectile, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(INpc npc, IBlock block)
        {
            Rectangle collisionFound = Rectangle.Intersect(npc.GetRectangle(), block.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(npc.GetRectangle(), block.GetRectangle(), collisionFound);
                handlerDictionary.GetNpcBlockHandler(npc.GetType()).HandleCollision(npc, block, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IProjectile projectile, IBlock block)
        {
            Rectangle collisionFound = Rectangle.Intersect(projectile.GetRectangle(), block.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(projectile.GetRectangle(), block.GetRectangle(), collisionFound);
                handlerDictionary.GetProjectileBlockHandler(projectile.GetType()).HandleCollision(projectile, block, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IItem item, IBlock block)
        {
            Rectangle collisionFound = Rectangle.Intersect(item.GetRectangle(), block.GetRectangle());
            if (!collisionFound.IsEmpty)
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(item.GetRectangle(), block.GetRectangle(), collisionFound);
                handlerDictionary.GetItemBlockHandler(block.GetType()).HandleCollision(item, block, side);
            }
        }
    }
}

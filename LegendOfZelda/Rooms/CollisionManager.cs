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

        public void CheckAndHandleAllCollisions()
        {
            CheckAndHandlePlayerCollisions();
            CheckAndHandleNpcCollisions();
            CheckAndHandleProjectileCollisions();
            CheckAndHandlerItemCollisions();
        }

        private void CheckAndHandlePlayerCollisions()
        {

            foreach (IPlayer player in spawnableManager.ItemList)
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

        private void CheckAndHandlerItemCollisions()
        {
            foreach (IItem item in spawnableManager.ItemList)
            {
                foreach (IBlock block in spawnableManager.BlockList)
                {
                    CheckIntersectionAndHandleCollision(item, block);
                }
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, INpc npc)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), npc.GetRectangle());
            if (!collisionFound.Equals(Rectangle.Empty))
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), npc.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerNpcHandler(npc.GetType()).HandleCollision(player, npc, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, IProjectile projectile)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), projectile.GetRectangle());
            if (!collisionFound.Equals(Rectangle.Empty))
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), projectile.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerProjectileHandler(projectile.GetType()).HandleCollision(player, projectile, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, IItem item)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), item.GetRectangle());
            if (!collisionFound.Equals(Rectangle.Empty))
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), item.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerItemHandler(item.GetType()).HandleCollision(player, item, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(IPlayer player, IBlock block)
        {
            Rectangle collisionFound = Rectangle.Intersect(player.GetRectangle(), block.GetRectangle());
            if (!collisionFound.Equals(Rectangle.Empty))
            {
                Constants.Direction side = UtilityMethods.GetCollisionDirection(player.GetRectangle(), block.GetRectangle(), collisionFound);
                handlerDictionary.GetPlayerBlockHandler(block.GetType()).HandleCollision(player, block, side);
            }
        }

        private void CheckIntersectionAndHandleCollision(INpc npc, IProjectile projectile)
        {
            Rectangle side = Rectangle.Intersect(npc.GetRectangle(), projectile.GetRectangle());
            if (!side.Equals(Rectangle.Empty))
            {
                Constants.Direction direction = UtilityMethods.GetCollisionDirection(npc.GetRectangle(), projectile.GetRectangle(), side);
                handlerDictionary.GetNpcProjectileHandler(projectile.GetType()).HandleCollision(npc, projectile, direction);
            }
        }

        private void CheckIntersectionAndHandleCollision(INpc npc, IBlock block)
        {
            Rectangle side = Rectangle.Intersect(npc.GetRectangle(), block.GetRectangle());
            if (!side.Equals(Rectangle.Empty))
            {
                Constants.Direction direction = UtilityMethods.GetCollisionDirection(npc.GetRectangle(), block.GetRectangle(), side);
                handlerDictionary.GetNpcBlockHandler(block.GetType()).HandleCollision(npc, block, direction);
            }
        }

        private void CheckIntersectionAndHandleCollision(IProjectile projectile, IBlock block)
        {
            Rectangle side = Rectangle.Intersect(projectile.GetRectangle(), block.GetRectangle());
            if (!side.Equals(Rectangle.Empty))
            {
                Constants.Direction direction = UtilityMethods.GetCollisionDirection(projectile.GetRectangle(), block.GetRectangle(), side);
                handlerDictionary.GetProjectileBlockHandler(block.GetType()).HandleCollision(projectile, block, direction);
            }
        }

        private void CheckIntersectionAndHandleCollision(IItem item, IBlock block)
        {
            Rectangle side = Rectangle.Intersect(item.GetRectangle(), block.GetRectangle());
            if (!side.Equals(Rectangle.Empty))
            {
                Constants.Direction direction = UtilityMethods.GetCollisionDirection(item.GetRectangle(), block.GetRectangle(), side);
                handlerDictionary.GetItemBlockHandler(block.GetType()).HandleCollision(item, block, side);
            }
        }
    }
}

using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.Link.CollisionHandler.WithBlock;
using LegendOfZelda.Link.CollisionHandler.WithItem;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class CollisionHandlerDictionary
    {
        // IPlayer Collision Dictionaries
        private Dictionary<Type, ICollision<IPlayer, INpc>> playerNpcDictionary;
        private Dictionary<Type, ICollision<IPlayer, IProjectile>> playerProjectileDictionary;
        private Dictionary<Type, ICollision<IPlayer, IItem>> playerItemDictionary;
        private Dictionary<Type, ICollision<IPlayer, IBlock>> playerBlockDictionary;

        // INpc Collision Dictionaries
        private Dictionary<Type, ICollision<INpc, IProjectile>> npcProjectileDictionary;
        private Dictionary<Type, ICollision<INpc, IBlock>> npcBlockDictionary;

        // IProjectile Collision Dictionary
        private Dictionary<Type, ICollision<IProjectile, IBlock>> projectileBlockDictionary;

        // IItem Collision Dictionary
        private Dictionary<Type, ICollision<IItem, IBlock>> itemBlockDictionary;

        public CollisionHandlerDictionary()
        {
            InitializePlayerCollisionDictionaries();
            InitializeNpcCollisionDictionaries();
            InitializeProjectileCollisionDictionaries();
            InitializeItemCollisionDictionaries();
        }

        public ICollision<IPlayer, INpc> GetPlayerNpcHandler(Type type)
        {
            return playerNpcDictionary[type];
        }

        public ICollision<IPlayer, IProjectile> GetPlayerProjectileHandler(Type type)
        {
            return playerProjectileDictionary[type];
        }

        public ICollision<IPlayer, IItem> GetPlayerItemHandler(Type type)
        {
            return playerItemDictionary[type];
        }

        public ICollision<IPlayer, IBlock> GetPlayerBlockHandler(Type type)
        {
            return playerBlockDictionary[type];
        }

        public ICollision<INpc, IProjectile> GetNpcProjectileHandler(Type type)
        {
            return npcProjectileDictionary[type];
        }

        public ICollision<INpc, IBlock> GetNpcBlockHandler(Type type)
        {
            return npcBlockDictionary[type];
        }

        public ICollision<IProjectile, IBlock> GetProjectileBlockHandler(Type type)
        {
            return projectileBlockDictionary[type];
        }

        public ICollision<IItem, IBlock> GetItemBlockHandler(Type type)
        {
            return itemBlockDictionary[type];
        }

        private void InitializePlayerCollisionDictionaries()
        {
            playerNpcDictionary = new Dictionary<Type, ICollision<IPlayer, INpc>>()
            {
                // TODO: initialize here
            };

            playerProjectileDictionary = new Dictionary<Type, ICollision<IPlayer, IProjectile>>()
            {
                // TODO: initialize here
            };

            playerItemDictionary = new Dictionary<Type, ICollision<IPlayer, IItem>>()
            {
                {typeof(BombItem), new LinkBombItemCollisionHandler() },
                {typeof(BoomerangItem), new LinkBoomerangItemCollisionHandler() },
                {typeof(BowItem), new LinkBowItemCollisionHandler() },
                {typeof(ClockItem), new LinkClockItemCollisionHandler() },
                {typeof(CompassItem), new LinkCompassItemCollisionHandler() },
                {typeof(FairyItem), new LinkFairyItemCollisionHandler() },
                {typeof(HeartContainerItem), new LinkHeartContainerItemCollisionHandler() },
                {typeof(HeartItem), new LinkHeartItemCollisionHandler() },
                {typeof(KeyItem), new LinkKeyItemCollisionHandler() },
                {typeof(MapItem), new LinkMapItemCollisionHandler() },
                {typeof(RupeeItem), new LinkRupeeItemCollision() },
                {typeof(TriforceItem), new LinkTriforceItemCollisionHandler() }
            };

            playerBlockDictionary = new Dictionary<Type, ICollision<IPlayer, IBlock>>()
            {
                // TODO: initialize here
                // fire
                // unmovable block
                    // water
                    // wall
                    // gap tile
                    // statue
                // movable block
            };
        }

        private void InitializeNpcCollisionDictionaries()
        {
            npcProjectileDictionary = new Dictionary<Type, ICollision<INpc, IProjectile>>
            {
                // TODO: initialize here
            };

            npcBlockDictionary = new Dictionary<Type, ICollision<INpc, IBlock>>()
            {
                // TODO: initialize here
            };
        }

        private void InitializeProjectileCollisionDictionaries()
        {
            projectileBlockDictionary = new Dictionary<Type, ICollision<IProjectile, IBlock>>
            {
                // TODO: initialize here
            };
        }

        private void InitializeItemCollisionDictionaries()
        {
            itemBlockDictionary = new Dictionary<Type, ICollision<IItem, IBlock>>()
            {
                // TODO: initialize me here
            };
        }
    }
}

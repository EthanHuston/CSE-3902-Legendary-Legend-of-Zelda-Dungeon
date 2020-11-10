using LegendOfZelda.Enemies;
using LegendOfZelda.Enemies.CollisionHandlers.WithBlock;
using LegendOfZelda.Enemies.CollisionHandlers.WithProjectile;
using LegendOfZelda.Environment;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.Item;
using LegendOfZelda.Link.CollisionHandler.WithBlock;
using LegendOfZelda.Link.CollisionHandler.WithItem;
using LegendOfZelda.Link.CollisionHandler.WithNpc;
using LegendOfZelda.Link.CollisionHandler.WithProjectile;
using LegendOfZelda.Link.CollisionHandlers.WithProjectile;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;
using LegendOfZelda.Projectile.CollisionHandler;
using LegendOfZelda.Rooms;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    internal class CollisionHandlerDictionary
    {
        // IPlayer Collision Dictionaries
        private Dictionary<Type, ICollisionHandler<IPlayer, INpc>> playerNpcDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IProjectile>> playerProjectileDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IItem>> playerItemDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IBlock>> playerBlockDictionary;

        // INpc Collision Dictionaries
        private Dictionary<Type, ICollisionHandler<INpc, IProjectile>> npcProjectileDictionary;
        private Dictionary<Type, ICollisionHandler<INpc, IBlock>> npcBlockDictionary;

        // IProjectile Collision Dictionary
        private Dictionary<Type, ICollisionHandler<IProjectile, IBlock>> projectileBlockDictionary;

        // IItem Collision Dictionary
        private Dictionary<Type, ICollisionHandler<IItem, IBlock>> itemBlockDictionary;

        public CollisionHandlerDictionary()
        {
            InitializePlayerCollisionDictionaries();
            InitializeNpcCollisionDictionaries();
            InitializeProjectileCollisionDictionaries();
            InitializeItemCollisionDictionaries();
        }

        public ICollisionHandler<IPlayer, INpc> GetPlayerNpcHandler(Type type)
        {
            return playerNpcDictionary[type];
        }

        public ICollisionHandler<IPlayer, IProjectile> GetPlayerProjectileHandler(Type type)
        {
            return playerProjectileDictionary[type];
        }

        public ICollisionHandler<IPlayer, IItem> GetPlayerItemHandler(Type type)
        {
            return playerItemDictionary[type];
        }

        public ICollisionHandler<IPlayer, IBlock> GetPlayerBlockHandler(Type type)
        {
            return playerBlockDictionary[type];
        }

        public ICollisionHandler<INpc, IProjectile> GetNpcProjectileHandler(Type type)
        {
            return npcProjectileDictionary[type];
        }

        public ICollisionHandler<INpc, IBlock> GetNpcBlockHandler(Type type)
        {
            return npcBlockDictionary[type];
        }

        public ICollisionHandler<IProjectile, IBlock> GetProjectileBlockHandler(Type type)
        {
            return projectileBlockDictionary[type];
        }

        public ICollisionHandler<IItem, IBlock> GetItemBlockHandler(Type type)
        {
            return itemBlockDictionary[type];
        }

        private void InitializePlayerCollisionDictionaries()
        {
            playerNpcDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, INpc>>()
            {
                {typeof(Aquamentus), new LinkNpcDamageCollisionHandler() },
                {typeof(Bat), new LinkNpcDamageCollisionHandler() },
                {typeof(Goriya), new LinkNpcDamageCollisionHandler() },
                {typeof(Hand), new LinkHandCollisionHandler() },
                {typeof(Jelly), new LinkNpcDamageCollisionHandler() },
                {typeof(Skeleton), new LinkNpcDamageCollisionHandler() },
                {typeof(SpikeTrap), new LinkNpcDamageCollisionHandler() },
                {typeof(OldMan), new LinkNpcDoNothingCollisionHandler() },
                {typeof(Merchant), new LinkNpcDoNothingCollisionHandler() },
            };

            playerProjectileDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IProjectile>>()
            {
                {typeof(ArrowFlyingProjectile), new LinkProjectileDoNothingCollisionHandler() },
                {typeof(BombExplodingProjectile), new LinkBombCollisionHandler() },
                {typeof(BoomerangFlyingProjectile), new LinkBoomerangCollisionHandler() },
                {typeof(FireballProjectile), new LinkFireballCollisionHandler() },
                {typeof(SwordAttackingProjectile), new LinkProjectileDoNothingCollisionHandler() },
                {typeof(SwordBeamFlyingProjectile), new LinkProjectileDoNothingCollisionHandler() },
            };

            playerItemDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IItem>>()
            {
                // TODO: fix me
                {typeof(BombItem), new LinkItemCollisionHandler() },
                {typeof(BoomerangItem), new LinkItemCollisionHandler() },
                {typeof(BowItem), new LinkItemCollisionHandler() },
                {typeof(ClockItem), new LinkItemCollisionHandler() },
                {typeof(CompassItem), new LinkItemCollisionHandler() },
                {typeof(FairyItem), new LinkFairyCollisionHandler() },
                {typeof(HeartContainerItem), new LinkItemCollisionHandler() },
                {typeof(HeartItem), new LinkHeartCollisionHandler() },
                {typeof(KeyItem), new LinkItemCollisionHandler() },
                {typeof(MapItem), new LinkItemCollisionHandler() },
                {typeof(RupeeItem), new LinkItemCollisionHandler() },
                {typeof(TriforceItem), new LinkTriforceCollisionHandler() }
            };

            playerBlockDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IBlock>>()
            {
                // immovable blocks
                {typeof(FishStatues), new LinkImmovableBlockCollisionHandler() },
                {typeof(DragonStatues), new LinkImmovableBlockCollisionHandler() },
                {typeof(TileWater), new LinkImmovableBlockCollisionHandler() },
                {typeof(Walls), new LinkImmovableBlockCollisionHandler() },
                {typeof(Square), new LinkImmovableBlockCollisionHandler() },
                {typeof(RoomWall), new LinkImmovableBlockCollisionHandler() },

                // interactive blocks
                {typeof(Fire), new LinkFireCollisionHandler() },
                {typeof(Stairs), new LinkStairsCollisionHandler() },
                {typeof(MovableSquare), new LinkMovableBlockCollisionHandler() },

                // doors
                {typeof(OpenDoor), new LinkDoorCollisionHandler() },
                {typeof(ShutDoor), new LinkDoorCollisionHandler() },
                {typeof(BombableOpening), new LinkDoorCollisionHandler() },
                {typeof(LockedDoor), new LinkLockedDoorCollisionHandler() },
                {typeof(RoomChangeTrigger), new  LinkRoomChangeTriggerCollisionHandler() }

            };
        }

        private void InitializeNpcCollisionDictionaries()
        {
            npcProjectileDictionary = new Dictionary<Type, ICollisionHandler<INpc, IProjectile>>
            {
                {typeof(ArrowFlyingProjectile), new EnemyArrowCollisionHandler() },
                {typeof(BombExplodingProjectile), new EnemyBombCollisionHandler() },
                {typeof(BoomerangFlyingProjectile), new EnemyBoomerangCollisionHandler() },
                {typeof(FireballProjectile), new EnemyProjectileDoNothingCollisionHandler() },
                {typeof(SwordAttackingProjectile), new EnemySwordCollisionHandler() },
                {typeof(SwordBeamFlyingProjectile), new EnemySwordBeamCollisionHandler() }
            };

            npcBlockDictionary = new Dictionary<Type, ICollisionHandler<INpc, IBlock>>()
            {
                {typeof(Aquamentus), new AquamentusBlockCollisionHandler() },
                {typeof(Bat), new BatBlockCollisionHandler() },
                {typeof(Goriya), new GoriyaBlockCollisionHandler() },
                {typeof(Hand), new HandBlockCollisionHandler() },
                {typeof(Jelly), new JellyBlockCollisionHandler() },
                {typeof(Skeleton), new SkeletonBlockCollisionHandler() },
                {typeof(SpikeTrap), new SpikeTrapBlockCollisionHandler() },
            };
        }

        private void InitializeProjectileCollisionDictionaries()
        {
            projectileBlockDictionary = new Dictionary<Type, ICollisionHandler<IProjectile, IBlock>>
            {
                {typeof(ArrowFlyingProjectile), new ArrowBlockCollisionHandler() },
                {typeof(BoomerangFlyingProjectile), new BoomerangBlockCollisionHandler() },
                {typeof(BombExplodingProjectile), new ProjectileBlockDoNothingCollisionHandler() },
                {typeof(FireballProjectile), new FireballBlockCollisionHandler() },
                {typeof(SwordAttackingProjectile), new ProjectileBlockDoNothingCollisionHandler()},
                {typeof(SwordBeamFlyingProjectile), new SwordBeamBlockCollisionHandler() }
            };
        }

        private void InitializeItemCollisionDictionaries()
        {
            itemBlockDictionary = new Dictionary<Type, ICollisionHandler<IItem, IBlock>>()
            {
                // TODO: initialize me here
            };
        }
    }
}

using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link
{
    internal static class LinkConstants
    {
        // General Constants
        public const double SpriteScaler = Constants.GameScaler;

        // Velocities
        public const int BoomerangSpeed = (int)(1 * SpriteScaler);
        public const int ArrowSpeed = (int)(2 * SpriteScaler);

        // Misc. Values
        public const int StartingHearts = 3 * HeartValue;
        public const int HeartValue = Constants.HeartValue;
        public const int HeartItemHealAmount = Constants.HeartValue;

        public const int DamageEffectTimeMs = 2000;
        public const int DamageFlashDelayTicks = 5;

        public const int PickUpItemPauseTicks = 60;
        public const int CollisionHelper = (int)(3 * SpriteScaler);

        public const int UsingSwordFrameDelay = 3;
        public const int SwordHitboxShortener = (int)(4 * SpriteScaler);

        // Inventory Starting Quantities
        public const int RupeeCount = 5;
        public const int BombCount = 2;
        public const int BoomerangCount = 0;
        public const int SwordCount = 1;
        public const int BowCount = 0;

        // Spawn Locations : Entering into Room
        public static Point DoorDownSpawnPosition => new Point(RoomConstants.BottomDoorX + RoomConstants.TileLength / 2, RoomConstants.BottomDoorY);
        public static Point DoorUpSpawnPosition => new Point(RoomConstants.TopDoorX + RoomConstants.TileLength / 2, RoomConstants.TopDoorY + RoomConstants.TileLength);
        public static Point DoorLeftSpawnPosition => new Point(RoomConstants.LeftDoorX + RoomConstants.TileLength, RoomConstants.LeftDoorY + RoomConstants.TileLength / 2);
        public static Point DoorRightSpawnPosition => new Point(RoomConstants.RightDoorX, RoomConstants.RightDoorY + RoomConstants.TileLength / 2);
        public static Point SecretRoomEnterSpawnPosition => new Point(RoomConstants.TileLength * 3, Constants.MinYPos);
        public static Point SecretRoomExitSpawnPosition => new Point(RoomConstants.WallWidth + 5 * RoomConstants.TileLength, Constants.MinYPos + RoomConstants.WallWidth + 3 * RoomConstants.TileLength);

        // Spawn Offsets : Picking Up Items
        public static Point PickingUpBoomerangSpawnOffset => new Point((int)(0 * SpriteScaler), (int)(-9 * SpriteScaler));
        public static Point PickingUpBowSpawnOffset => new Point((int)(0 * SpriteScaler), (int)(-15 * SpriteScaler));
        public static Point PickingUpHeartContainerSpawnOffset => new Point((int)(0 * SpriteScaler), (int)(-14 * SpriteScaler));
        public static Point PickingUpSwordSpawnOffset => new Point((int)(0 * SpriteScaler), (int)(-12 * SpriteScaler));
        public static Point PickingUpTriforceSpawnOffset => new Point((int)(0 * SpriteScaler), (int)(-11 * SpriteScaler));

        // Spawn Offsets : Using Items
        public static Point ShootingArrowSpawnOffset => new Point((int)(3 * SpriteScaler), (int)(7 * SpriteScaler));
        public static Point ShootingSwordBeamSpawnOffset => new Point((int)(2 * SpriteScaler), (int)(6 * SpriteScaler));
        public static Point ShootingBoomerangSpawnOffset => new Point((int)(4 * SpriteScaler), (int)(8 * SpriteScaler));

        // Spawn Offsets : Using Sword
        public static Point UsingSwordRightSpawnOffset => new Point((int)(14 * SpriteScaler), (int)(0 * SpriteScaler));
        public static Point UsingSwordLeftSpawnOffset => new Point((int)(-14 * SpriteScaler), (int)(0 * SpriteScaler));
        public static Point UsingSwordUpSpawnOffset => new Point((int)(0 * SpriteScaler), (int)(-16 * SpriteScaler));
        public static Point UsingSwordDownSpawnOffset => new Point((int)(0 * SpriteScaler), (int)(16 * SpriteScaler));

        // Link's Item Types
        public enum ItemType
        {
            Rupee,
            Bomb,
            Bow,
            Boomerang,
            Clock,
            Compass,
            Fairy,
            Heart,
            HeartContainer,
            Key,
            Map,
            Sword,
            SwordBeam,
            Triforce,
            None,
            Candle
        }

        public enum ProjectileType
        {
            Arrow,
            Bomb,
            Boomerang,
            Fireball,
            Sword,
            SwordBeam
        }
    }
}
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link
{
    static class LinkConstants
    {
        // Velocities
        public const int BoomerangSpeed = 1;
        public const int ArrowSpeed = 2;

        // Spawn Offsets : Picking Up Items
        public static Point PickingUpBoomerangSpawnOffset => new Point(0, -9);
        public static Point PickingUpBowSpawnOffset => new Point(0, -15);
        public static Point PickingUpHeartContainerSpawnOffset => new Point(0, -14);
        public static Point PickingUpSwordSpawnOffset => new Point(0, -12);
        public static Point PickingUpTriforceSpawnOffset => new Point(0, -11);

        // Spawn Offsets : Using Items
        public static Point ShootingArrowSpawnOffset => new Point(3, 7);
        public static Point ShootingSwordBeamSpawnOffset => new Point(2, 6);
        public static Point ShootingBoomerangSpawnOffset => new Point(4, 8);

        public enum ItemType
        {
            Arrow,
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
            Triforce
        }
    }
}
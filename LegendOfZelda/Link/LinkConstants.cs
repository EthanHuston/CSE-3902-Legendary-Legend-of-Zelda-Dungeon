using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link
{
    static class LinkConstants
    {
        // Velocities
        public static int BoomerangSpeed = 1;

        // Spawn Offsets
        public static Point PickingUpBoomerangSpawnOffset => new Point(0, -9);
        public static Point PickingUpBowSpawnOffset => new Point(0, -15);
        public static Point PickingUpHeartContainerSpawnOffset => new Point(0, -14);
        public static Point PickingUpSwordSpawnOffset => new Point(0, -12);
        public static Point PickingUpTriforceSpawnOffset => new Point(0, -11);

        public enum LinkInventory
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
namespace LegendOfZelda
{
    public static class Constants
    {
        public const int Number = 69;
        public const int FrameDelay = 6;
        public const double SpriteScaler = 1;

        // Link
        public const int LinkWalkStepDistanceInterval = 1;
        public const int LinkWalkDistanceInterval = 20;
        public const int LinkHealth = 100;
        public const int LinkDamageEffectTimeMs = 2000;
        public const int LinkDamageFlashDelayTicks = 5;
        public const int LinkPickingUpItemPauseTicks = 60;
        public const int LinkUsingItemPauseTicks = 5;
        public const int LinkStrikingPauseTicks = 5;
        public const int LinkWalkingFrameDelay = 10;

        // Link's Items
        public const int ArrowSpawnXOffsetFromLink = 0;
        public const int ArrowSpawnYOffsetFromLink = 6;
        public const int BombSpawnXOffsetFromLink = 0;
        public const int BombSpawnYOffsetFromLink = 6;
        public const int BoomerangSpawnXOffsetFromLink = 0;
        public const int BoomerangSpawnYOffsetFromLink = 6;
        public const int BoomerangMaxDistanceFromLink = 300;
        public const int SwordBeamSpawnXOffsetFromLink = 4;
        public const int SwordBeamSpawnYOffsetFromLink = 5;

        // Game Screen
        public const int MaxXPos = 800;
        public const int MinXPos = 0;
        public const int MaxYPos = 480;
        public const int MinYPos = 0;

        // Directions
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }

        // Items
        public enum Item
        {
            ArrowFlying,
            BombExploding,
            BoomerangFlying,
            SwordBeamFlying
        }

        public enum ItemOwner
        {
            Link,
            Room,
            Enemy
        }

        //Enemy Constants
        public const int SpikeTrapMaxDist = 50;
        public const int SpikeTrapGoingVelocity = 4;
        public const int SpikeTrapReturningVelocity = 2;

        //Room Constants
        public const int roomWidth = 12;
        public const int roomHeight = 7;
    }
}

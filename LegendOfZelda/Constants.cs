namespace Sprint0
{
    public static class Constants
    {
        public const int Number = 69;
        public const int Sprint2LinkSpawnX = 0;
        public const int Sprint2LinkSpawnY = 0;
        public const int FrameDelay = 6;
        public const double SpriteScaler = 1;

        // Link
        public const int LinkWalkDistanceIntervalPx = 5;
        public const int LinkHealth = 100;
        public const int LinkDamageEffectTimeMs = 2000;
        public const int LinkDamageFlashDelayTicks = 5;
        public const int LinkPickingUpItemPauseTicks = 5;
        public const int LinkUsingItemPauseTicks = 5;
        public const int LinkStrikingPauseTicks = 5;
        public const int ArrowSpawnXOffsetFromLink = 0;
        public const int ArrowSpawnYOffsetFromLink = 6;
        public const int BombSpawnXOffsetFromLink = 0;
        public const int BombSpawnYOffsetFromLink = 6;
        public const int BombDelayBeforeExplosion = 60;


        // Game screen
        public const int MaxXPos = 800;
        public const int MinXPos = 0;
        public const int MaxYPos = 480;
        public const int MinYPos = 0;

        // Directions
        public enum Directions
        {
            Right,
            Left,
            Up,
            Down
        }

        // Items
        public enum Items
        {
            Arrow,
            Bomb,
            Boomerang
        }
        public const int FlyingArrowDistanceIntervalPx = 5;
    }
}

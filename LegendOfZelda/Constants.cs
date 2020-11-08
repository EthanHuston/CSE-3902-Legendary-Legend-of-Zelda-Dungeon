using LegendOfZelda.HUDClasses;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public static class Constants
    {
        public const int FrameDelay = 6;
        public const double GameScaler = 1;
        public const int HeartValue = 10;
        public const float MusicVolume = 0f; // TODO: turn sound back on

        // Game Screen
        public static Vector2 GameSize => new Vector2(MaxXPos, MaxYPos);
        public const int MaxXPos = RoomConstants.RoomWidth;
        public const int MinXPos = 0;
        public const int MaxYPos = HUDConstants.hudHeight + RoomConstants.RoomHeight;
        public const int MinYPos = HUDConstants.hudHeight;
        public const int HalfXPos = MaxXPos / 2;
        public const int HalfYPos = MaxYPos / 2;

        // Damage from Different Items
        public const double ArrowDamage = 2 * HeartValue;
        public const double BombDamage = 4.0 * HeartValue;
        public const double BoomerangDamage = .5 * HeartValue;
        public const double SwordBeamDamage = 1.0 * HeartValue;
        public const double FireballDamage = 0.5 * HeartValue;
        public const double SwordDamage = 1 * HeartValue; // TODO lookup damage
        public const double FireTileDamage = 0.5 * HeartValue;

        // Damage from Enemies
        public const double LinkEnemyCollisionDamage = 0.5 * HeartValue;

        // Directions
        public enum Direction
        {
            Up, Right, Down, Left, None
        }

        public enum ProjectileOwner
        {
            Link,
            Enemy
        }

        //Enemy Constants
        public const int SpikeTrapMaxDistX = ((RoomConstants.RoomWidth - (2 * RoomConstants.WallWidth)) / 2) - RoomConstants.TileLength;
        public const int SpikeTrapMaxDistY = ((RoomConstants.RoomHeight - (2 * RoomConstants.WallWidth)) / 2) - RoomConstants.TileLength;
        public const int SpikeTrapGoingVelocity = 2;
        public const int SpikeTrapReturningVelocity = 1;
        public const int MovableSquareVelocity = 1;
        public const float EnemyMoveUp = -1;
        public const float EnemyMoveDown = 1;
        public const float EnemyMoveRight = 1;
        public const float EnemyMoveLeft = -1;
        public const float EnemyNoMove = 0;
        public const int EnemyDamageEffectTimeMs = 500;
        public const int EnemyDamageFlashDelayTicks = 5;

    }
}

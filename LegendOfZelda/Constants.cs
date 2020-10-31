using Microsoft.Xna.Framework;
using System;
using System.Diagnostics.PerformanceData;
using LegendOfZelda.Rooms;

namespace LegendOfZelda
{
    public static class Constants
    {
        public const int FrameDelay = 6;
        public const double GameScaler = 1;
        public const int HeartValue = 10;

        // Game Screen
        public static Vector2 GameSize => new Vector2(MaxXPos, MaxYPos);
        public const int MaxXPos = RoomConstants.roomWidth;
        public const int MinXPos = 0;
        public const int MaxYPos = RoomConstants.roomHeight;
        public const int MinYPos = 0;
        public const int HalfXPos = MaxXPos / 2;
        public const int HalfYPos = MaxYPos / 2;

        // Damage from Different Items
        public const double ArrowDamage = 2.0;
        public const double BombDamage = 4.0;
        public const double BoomerangDamage = .5;
        public const double SwordBeamDamage = 1.0;
        public const double FireballDamage = 0.5;
        public const double SwordDamage = 1; // TODO lookup damage
        public const double FireTileDamage = 0.5;

        // Damage from Enemies
        public const double LinkEnemyCollisionDamage = 0.5;

        // Directions
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down,
            None
        }

        public enum ProjectileOwner
        {
            Link,
            Enemy
        }

        //Enemy Constants
        public const int SpikeTrapMaxDistX = ((RoomConstants.roomWidth - (2 * RoomConstants.wallWidth)) / 2) - RoomConstants.tileLength;
        public const int SpikeTrapMaxDistY = ((RoomConstants.roomHeight - (2 * RoomConstants.wallWidth)) / 2) - RoomConstants.tileLength;
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

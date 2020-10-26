using Microsoft.Xna.Framework;
using System;
using System.Diagnostics.PerformanceData;
using LegendOfZelda.Rooms;

namespace LegendOfZelda
{
    public static class Constants
    {
        public const int SpriteScaler = 1;
        public const int Number = 69;
        public const int FrameDelay = 6;
        public const double GameScaler = 1;
        public const int WallWidth = 32;

        // Game Screen
        public static Vector2 GameSize = new Vector2(MaxXPos, MaxYPos);
        public const int MaxXPos = RoomConstants.roomWidth;
        public const int MinXPos = 0;
        public const int MaxYPos = RoomConstants.roomHeight;
        public const int MinYPos = 0;
        public const int HalfXPos = MaxXPos / 2;
        public const int HalfYPos = MaxYPos / 2;

        // Link
        public const int LinkWalkStepDistanceInterval = 1;
        public const int LinkWalkDistanceInterval = 8;
        public const int LinkStartingHealth = 60;
        public const int LinkDamageEffectTimeMs = 2000;
        public const int LinkDamageFlashDelayTicks = 5;
        public const int LinkPickingUpItemPauseTicks = 60;
        public const int LinkUsingItemPauseTicks = 5;
        public const int LinkStrikingPauseTicks = 5;
        public const int LinkWalkingFrameDelay = 10;
        public const float LinkMoveUp = -1;
        public const float LinkMoveDown = 1;
        public const float LinkMoveRight = 1;
        public const float LinkMoveLeft = -1;
        public const float LinkNoMove = 0;
        public const int LinkCollisionHelper = 3 * SpriteScaler;
        public const int DragAgainDelayMs = 5000;
        public static Point LinkDoorDownSpawnPosition => new Point(120, 128);
        public static Point LinkDoorUpSpawnPosition => new Point(120, 32);
        public static Point LinkDoorLeftSpawnPosition => new Point(32, 80);
        public static Point LinkDoorRightSpawnPosition => new Point(208, 80);

        // Link's Items
        public const int ArrowSpawnXOffsetFromLink = 0;
        public const int ArrowSpawnYOffsetFromLink = 6;
        public const int BombSpawnXOffsetFromLink = 0;
        public const int BombSpawnYOffsetFromLink = 6;
        public const int BoomerangSpawnXOffsetFromLink = 0;
        public const int BoomerangSpawnYOffsetFromLink = 6;
        public const int BoomerangVelocity = 6;
        public const int SwordBeamSpawnXOffsetFromLink = 4;
        public const int SwordBeamSpawnYOffsetFromLink = 5;

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

        // Moveable Block
        public const float MBlockMoveUp = -1;
        public const float MBlockMoveDown = 1;
        public const float MBlockMoveRight = 1;
        public const float MBlockMoveLeft = -1;
        public const float MBlockNoMove = 0;

        // Directions
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down,
            None
        }

        public enum ItemOwner
        {
            Link,
            Room,
            Enemy
        }

        public enum LinkInventory
        {
            Arrow,
            Bomb,
            Map,
            Key,
            Compass,
            Heart,
            Fairy,
            Clock
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

    }
}

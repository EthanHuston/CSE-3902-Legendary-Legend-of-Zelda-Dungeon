using LegendOfZelda.HUDClasses;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public static class RoomConstants
    {
        //Room Constants
        public const double SpriteMultiplier = Constants.GameScaler;
        public const int roomBorderX = 0;
        public const int roomBorderY = HUDConstants.hudHeight;
        public const int roomWidth = (int)(256 * SpriteMultiplier);
        public const int roomHeight = (int)(176 * SpriteMultiplier);
        public const int tileLength = (int)(16 * SpriteMultiplier);
        public const int wallWidth = (int)(32 * SpriteMultiplier);
        public const int bottomOfScreen = roomBorderY + roomHeight;
        public const int rightOfScreen = roomBorderX + roomWidth;
        public const int backgroundX = roomBorderX + wallWidth;
        public const int backgroundY = roomBorderY + wallWidth;
        public const int topDoorX = roomBorderX + (roomWidth - wallWidth) / 2;
        public const int topDoorY = roomBorderY;
        public const int rightDoorX = roomBorderX + roomWidth - wallWidth;
        public const int rightDoorY = roomBorderY + (roomHeight - wallWidth) / 2;
        public const int bottomDoorX = topDoorX;
        public const int bottomDoorY = roomBorderY + roomHeight - wallWidth;
        public const int leftDoorX = roomBorderX;
        public const int leftDoorY = rightDoorY;
        public const int NumberRooms = 17;
        private const int wallBlockShortener = 1;
        public static Random randomGenerator = new Random();
        public static Rectangle LeftWallRectangle => new Rectangle(roomBorderX, roomBorderY, wallWidth - (int)(wallBlockShortener * SpriteMultiplier), bottomOfScreen);
        public static Rectangle RightWallRectangle => new Rectangle(rightOfScreen - wallWidth, roomBorderY, wallWidth + (int)(wallBlockShortener * SpriteMultiplier), bottomOfScreen);
        public static Rectangle UpWallRectangle => new Rectangle(roomBorderX, roomBorderY, roomBorderX + roomWidth - (int)(wallBlockShortener * SpriteMultiplier), roomBorderY + wallWidth);
        public static Rectangle DownWallRectangle => new Rectangle(roomBorderX, bottomOfScreen - wallWidth, roomBorderX + roomWidth, bottomOfScreen);
        //String Abbreviations for Tiles in CSV File
        public const string Block = "block";
        public const string BrickTile = "brick";
        public const string Fire = "fire";
        public const string GapTile = "black";
        public const string LadderTile = "lad";
        public const string MovableBlock = "redblock";
        public const string Stairs = "stairs";
        public const string Statue = "stat";
        public const string BlueGrass = "bg";
        public const string Water = "water";
        //String Abbreviations for Border and Background in CSV File
        public const string TileBackground = "tealBack";
        public const string BlackBackground = "blackBack";
        public const string WallPiece = "wall";
        public const string OpenDoor = "open";
        public const string LockedDoor = "locked";
        public const string ShutDoor = "shut";
        public const string BombableWall = "wallBom";
        //String Abbreviations for Enemies in CSV File
        public const string Aquamentus = "aquamentus";
        public const string Bat = "bat";
        public const string Goriya = "goriya";
        public const string Hand = "hand";
        public const string Jelly = "jelly";
        public const string OldMan = "oldman";
        public const string Skeleton = "skeleton";
        public const string SpikeTrap = "spiketrap";
        //String Abbreviations for Items in CSV File
        public const string Compass = "compass";
        public const string Heart = "heart";
        public const string Key = "key";
        public const string Map = "map";
        public const string Triforce = "triforce";
    }
}

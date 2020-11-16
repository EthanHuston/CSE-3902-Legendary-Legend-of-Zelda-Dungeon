using LegendOfZelda.HUDClasses;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public static class RoomConstants
    {
        //Room Constants
        public const double SpriteMultiplier = Constants.GameScaler;
        public const int RoomBorderX = 0;
        public const int RoomBorderY = HUDConstants.hudHeight;
        public const int RoomWidth = (int)(256 * SpriteMultiplier);
        public const int RoomHeight = (int)(176 * SpriteMultiplier);
        public const int TileLength = (int)(16 * SpriteMultiplier);
        public const int WallWidth = (int)(32 * SpriteMultiplier);
        public const int BottomOfScreen = RoomBorderY + RoomHeight;
        public const int RightOfScreen = RoomBorderX + RoomWidth;
        public const int BackgroundX = RoomBorderX + WallWidth;
        public const int BackgroundY = RoomBorderY + WallWidth;
        public const int TopDoorX = RoomBorderX + (RoomWidth - WallWidth) / 2;
        public const int TopDoorY = RoomBorderY;
        public const int RightDoorX = RoomBorderX + RoomWidth - WallWidth;
        public const int RightDoorY = RoomBorderY + (RoomHeight - WallWidth) / 2;
        public const int BottomDoorX = TopDoorX;
        public const int BottomDoorY = RoomBorderY + RoomHeight - WallWidth;
        public const int LeftDoorX = RoomBorderX;
        public const int LeftDoorY = RightDoorY;
        public const int NumberRooms = 17;
        public static Random RandomGenerator = new Random();

        // Wall Collision Rectangles
        private const int upDownWallBlockLength = RoomWidth - RoomWidth / 2 - WallWidth / 2;
        private const int rightLeftWallBlockLength = RoomHeight - RoomHeight / 2 - WallWidth / 2;
        private const int wallBlockLengthBooster = (int)(8 * SpriteMultiplier);
        private const int wallBlockWidth = WallWidth;
        private const int rightSideWallBlockX = RightOfScreen - WallWidth;
        private const int rightTopBottomWallBlockX = RightOfScreen - upDownWallBlockLength;
        private const int leftWallBlockX = 0;
        private const int upWallBlockY = HUDConstants.hudHeight;
        private const int downSideWallBlockY = BottomOfScreen - rightLeftWallBlockLength;
        private const int downBottomWallBlockY = BottomOfScreen - WallWidth;
        public static Rectangle LeftUpWallRectangle => new Rectangle(leftWallBlockX, upWallBlockY, wallBlockWidth, rightLeftWallBlockLength + wallBlockLengthBooster);
        public static Rectangle LeftDownWallRectangle => new Rectangle(leftWallBlockX, downSideWallBlockY - wallBlockLengthBooster, wallBlockWidth, rightLeftWallBlockLength + wallBlockLengthBooster);
        public static Rectangle RightUpWallRectangle => new Rectangle(rightSideWallBlockX, upWallBlockY, wallBlockWidth, rightLeftWallBlockLength + wallBlockLengthBooster);
        public static Rectangle RightDownWallRectangle => new Rectangle(rightSideWallBlockX, downSideWallBlockY - wallBlockLengthBooster, wallBlockWidth, rightLeftWallBlockLength + wallBlockLengthBooster);
        public static Rectangle UpLeftWallRectangle => new Rectangle(leftWallBlockX, upWallBlockY, upDownWallBlockLength + wallBlockLengthBooster, wallBlockWidth);
        public static Rectangle UpRightWallRectangle => new Rectangle(rightTopBottomWallBlockX - wallBlockLengthBooster, upWallBlockY, upDownWallBlockLength + wallBlockLengthBooster, wallBlockWidth);
        public static Rectangle DownLeftWallRectangle => new Rectangle(leftWallBlockX, downBottomWallBlockY, upDownWallBlockLength + wallBlockLengthBooster, wallBlockWidth);
        public static Rectangle DownRightWallRectangle => new Rectangle(rightTopBottomWallBlockX - wallBlockLengthBooster, downBottomWallBlockY, upDownWallBlockLength + wallBlockLengthBooster, wallBlockWidth);

        // Secret Room Wall Rectangles
        private const int heightBooster = (int)(5 * Constants.GameScaler);
        public static Rectangle LeftWallRectangle => new Rectangle(2 * TileLength, Constants.MinYPos + 7 * TileLength, TileLength, TileLength + heightBooster);
        public static Rectangle MiddleWallRectangle => new Rectangle(4 * TileLength, Constants.MinYPos + 7 * TileLength, 6 * TileLength, TileLength + heightBooster);
        public static Rectangle RightWallRectangle => new Rectangle(11 * TileLength, Constants.MinYPos + 7 * TileLength, 2 * TileLength, TileLength + heightBooster);
        public static Rectangle TopWallRectangle => new Rectangle(6 * TileLength, Constants.MinYPos + 3 * TileLength, 7 * TileLength, 2 * TileLength + heightBooster);
        public static Rectangle SecretRoomRoomChangeTrigger => new Rectangle(3 * TileLength, Constants.MinYPos - roomChangeTriggerWidth, roomChangeTriggerLength, roomChangeTriggerWidth);

        // Room Change Triggers
        private const int roomChangeTriggerWidth = 20;
        private const int roomChangeTriggerLength = WallWidth;
        public static Rectangle RoomChangeRightTrigger => new Rectangle(RightDoorX + WallWidth - roomChangeTriggerWidth, RightDoorY, roomChangeTriggerWidth, roomChangeTriggerLength);
        public static Rectangle RoomChangeLeftTrigger => new Rectangle(LeftDoorX, LeftDoorY, roomChangeTriggerWidth, roomChangeTriggerLength);
        public static Rectangle RoomChangeDownTrigger => new Rectangle(BottomDoorX, BottomDoorY + WallWidth - roomChangeTriggerWidth, roomChangeTriggerLength, roomChangeTriggerWidth);
        public static Rectangle RoomChangeUpTrigger => new Rectangle(TopDoorX, TopDoorY, roomChangeTriggerLength, roomChangeTriggerWidth);

        // Door Locations on Texture Atlas
        public const int OpenDoorColumn = 0;
        public const int LockedDoorColumn = 1;
        public const int CrackedDoorColumn = 2;
        public const int BombedDoorColumn = 3;
        public const int BombableDoorColumn = 4;
        public const int UpDoorRow = 0;
        public const int LeftDoorRow = 1;
        public const int RightDoorRow = 2;
        public const int DownDoorRow = 3;

        //String Abbreviations for Tiles in CSV File
        public const string Block = "block";
        public const string BrickTile = "brick";
        public const string Fire = "fire";
        public const string GapTile = "black";
        public const string LadderTile = "ladder";
        public const string MovableBlock = "redblock";
        public const string Stairs = "stairs";
        public const string FishStatue = "fstat";
        public const string DragonStatue = "dstat";
        public const string BlueGrass = "bg";
        public const string Water = "water";
        public const string RoomBorder = "roomBorder";
        //String Abbreviations for Border and Background in CSV File
        public const string TileBackground = "tealBack";
        public const string BlackBackground = "blackBack";
        public const string OldBackground = "oldBack";
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
        public const string HeartContainer = "hrtcontainer";
        public const string Bow = "bow";
    }
}

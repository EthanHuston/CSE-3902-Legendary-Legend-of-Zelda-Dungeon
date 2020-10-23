using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public static class RoomConstants
    {
        //Room Constants
        public const int spriteMultiplier = 1;
        public const int roomWidth = 256;
        public const int roomHeight = 176;
        public const int tileLength = 16;
        public const int roomBorderX = 0;
        public const int roomBorderY = 0;
        public const int wallWidth = 32;
        public const int backgroundX = wallWidth * spriteMultiplier;
        public const int backgroundY = wallWidth * spriteMultiplier;
        public const int topDoorX = (roomWidth / 2 - wallWidth) * spriteMultiplier , topDoorY = 0;
        public const int rightDoorX = (roomWidth - wallWidth) * spriteMultiplier;
        public const int rightDoorY = (roomHeight - wallWidth) / 2 * spriteMultiplier;
        public const int bottomDoorX = topDoorX;
        public const int bottomDoorY = (roomHeight - wallWidth);
        public const int leftDoorX = roomBorderX;
        public const int leftDoorY = rightDoorY;
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

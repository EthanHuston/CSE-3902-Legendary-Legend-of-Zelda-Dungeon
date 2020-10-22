using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public static class RoomConstants
    {
        //Room Constants
        public const int roomWidth = 12;
        public const int roomHeight = 7;
        public const int tileLength = 16;
        public const int spriteMultiplier = 4;
        public const int topDoorX = 400, topDoorY = 0;
        public const int rightDoorX = 800, rightDoorY = 240;
        public const int bottomDoorX = 400, bottomDoorY = 480;
        public const int leftDoorX = 0, leftDoorY = 240;
        public const int backgroundX = 0, backgroundY = 0;
        public const int roomBorderX = 0, roomBorderY = 0;
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

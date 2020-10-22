using LegendOfZelda.Environment;
using LegendOfZelda.Interface;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Rooms
{
    class CSVReader
    {
        public ISpawnableManager allObjects = new SpawnableManager();
        private SpriteBatch spriteBatch;
        private const int tileLength = 16;
        //String Abbreviations for Tiles in CSV File
        const string Block = "block";
        const string BrickTile = "brick";
        const string Fire = "fire";
        const string GapTile = "black";
        const string LadderTile = "lad";
        const string MovableBlock = "redblock";
        const string Stairs = "stairs";
        const string Statue = "stat";
        const string BlueGrass = "bg";
        const string Water = "water";
        //String Abbreviations for Border and Background in CSV File
        const string TileBackground = "tealBack";
        const string BlackBackground = "blackBack";
        const string WallPiece = "wall";
        const string OpenDoor = "open";
        const string LockedDoor = "locked";
        const string ShutDoor = "shut";
        const string BombableWall = "wallBom";
        //String Abbreviations for Enemies in CSV File
        const string Aquamentus = "aquamentus";
        const string Bat = "bat";
        const string Goriya = "goriya";
        const string Hand = "hand";
        const string Jelly = "jelly";
        const string OldMan = "oldman";
        const string Skeleton = "skeleton";
        const string SpikeTrap = "spiketrap";
        //String Abbreviations for Items in CSV File
        const string Compass = "compass";
        const string Heart = "heart";
        const string Key = "key";
        const string Map = "map";
        const string Triforce = "triforce";

        public CSVReader(SpriteBatch spriteBatch, string fileName)
        {
            this.spriteBatch = spriteBatch;
            TextFieldParser parser = new TextFieldParser(fileName);
            parser.Delimiters = new string[] { "," }; //Delimiters are like separators in NextWordOrSeparator
            int j = 0;
            //Read each line of the file
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                if (j == 0)
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        spawnWallsAndBackground(fields[i], i);
                    }
                }
                else
                {
                    for(int i = 0; i < fields.Length; i++)
                    {
                        spawnFromString(fields[i], i, j);
                    }
                }
                j++;
            }
        }

        private void spawnFromString(string spawnType, int gridX, int gridY)
        {
            Point position = new Point(gridX * tileLength, gridY * tileLength);
            IBlock blockType;

            switch (spawnType)
            {
                case Block:
                    break;
                case BrickTile:
                    blockType = new BrickTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case GapTile:
                    blockType = new GapTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Fire:
                    blockType = new Fire(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case LadderTile:
                    blockType = new LadderTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Stairs:
                    blockType = new Stairs(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Statue:
                    blockType = new Statues(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case BlueGrass:
                    blockType = new TileBlueGrass(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case Water:
                    blockType = new TileWater(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                default:
                    break;

            }
        }

        private void spawnWallsAndBackground(string spawnType, int i)
        {
            IBlock blockType;
            Point position = Point.Zero;
            if (i == 1)
            {
                position = new Point(0, 0);
            }
            allObjects.Spawn(new RoomBorder(spriteBatch, new Point(0, 0)));
            switch (spawnType)
            {
                case TileBackground:
                    break;
                case BlackBackground:
                    break;
                case WallPiece:
                    break;
                case OpenDoor:
                    blockType = new OpenDoor(spriteBatch, position);
                    break;
                case LockedDoor:
                    break;
                case ShutDoor:
                    break;
                case BombableWall:
                    break;
                default:
                    break;

            }
        }

    }
}

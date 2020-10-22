using LegendOfZelda.Environment;
using LegendOfZelda.Interface;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Rooms
{
    class CSVReader
    {
        public IItemSpawner allObjects = new ItemSpawner();
        private SpriteBatch spriteBatch;
        private const int tileLength = 16;
        //String Abbreviations for Tiles in CSV File
        const string Block = "block";
        const string BlueTile = "---";
        const string BrickTile = "brick";
        const string Fire = "fire";
        const string GapTile = "black";
        const string LadderTile = "lad";
        const string Stairs = "stairs";
        const string Statue = "stat";
        const string BlueGrass = "bg";
        const string Water = "water";
        //String Abbreviations for Border and Background in CSV File
        const string TileBackground = "tileBack";
        const string BlackBackground = "blackBack";
        const string Walls = "walls";
        //String Abbreviations for Enemies in CSV File
        const string Aquamentus = "Aquamentus";
        const string Bat = "Bat";
        const string Goriya = "Goriya";
        const string Hand = "Hand";
        const string Jelly = "Jelly";
        const string OldMan = "OldMan";
        const string Skeleton = "Skeleton";
        const string SpikeTrap = "SpikeTrap";

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
                        spawnWallsAndBackground(fields[i]);
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

        private void spawnWallsAndBackground(string spawnType)
        {
            IBlock blockType;
            switch (spawnType)
            {
                case TileBackground:
                    break;
                default:
                    break;

            }
        }

    }
}

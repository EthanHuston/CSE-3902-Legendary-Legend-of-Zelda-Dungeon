using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace LegendOfZelda.Rooms
{
    class CVSReader
    {
        string[,] roomString = new string[Constants.roomWidth, Constants.roomHeight];
        ItemSpawner spawner = new ItemSpawner();
        private SpriteBatch spriteBatch;
        private const int tileLength = 16;
        //String Abbreviations from CSV File
        string BlueTile = "---";
        string BrickTile = "";
        string GapTile = "";
        string LadderTile = "";
        string Stairs = "";
        string Statue = "";
        string BlueGrass = "";
        string Water = "";

        public CVSReader(SpriteBatch spriteBatch, string fileName)
        {
            this.spriteBatch = spriteBatch;
            TextFieldParser parser = new TextFieldParser(fileName);
            parser.Delimiters = new string[] { "," }; //Delimiters are like separators in NextWordOrSeparator
            int j = 0;
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                for(int i = 0; i < fields.Length; i++)
                {
                    roomString[i, j] = fields[i];
                }
            }
        }

        private void spawnFromString(string spawnType, int gridX, int gridY)
        {
            Point position = new Point(gridX * tileLength, gridY * tileLength);
            IBlock blockType;

            switch (spawnType)
            {
                case BlueTile:
                    break;
                case BrickTile:
                    blockType = new BrickTile(spriteBatch, position);
                    spawner.Spawn(blockType);
                    break;
                case GapTile:
                    blockType = new GapTile(spriteBatch, position);
                    spawner.Spawn(blockType);
                    break;
                case LadderTile:
                    blockType = new LadderTile(spriteBatch, position);
                    spawner.Spawn(blockType);
                    break;
                case Stairs:
                    blockType = new Stairs(spriteBatch, position);
                    spawner.Spawn(blockType);
                    break;
                case Statues:
                    blockType = new Statues(spriteBatch, position);
                    spawner.Spawn(blockType);
                    break;
                case BlueGrass:
                    blockType = new BlueGrass(spriteBatch, position);
                    spawner.Spawn(blockType);
                    break;
                case Water:
                    blockType = new Water(spriteBatch, position);
                    spawner.Spawn(blockType);
                    break;

            }
        }

    }
}

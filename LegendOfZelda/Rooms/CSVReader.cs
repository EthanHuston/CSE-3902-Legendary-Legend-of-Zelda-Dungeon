using LegendOfZelda.Enemies;
using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using LegendOfZelda.Rooms.RoomImplementation;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Rooms
{
    internal class CSVReader
    {
        public IRoom room;
        private readonly SpriteBatch spriteBatch;

        public CSVReader(SpriteBatch spriteBatch, IRoom room, string fileName)
        {
            this.room = room;
            this.spriteBatch = spriteBatch;
            bool spawningSecretRoom = room.GetType() == typeof(SecretRoom);
            // Directory.GetCurrentDirectory() + "\\" + 
            TextFieldParser parser = new TextFieldParser(fileName)
            {
                Delimiters = new string[] { "," } //Delimiters are like separators in NextWordOrSeparator
            };
            int j = 0;
            //Read each line of the file
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                if (j == 0)
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        SpawnWallsAndBackground(fields[i], i);
                    }
                }
                else
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        SpawnFromString(fields[i], 
                            spawningSecretRoom ? RoomConstants.RoomBorderX : RoomConstants.BackgroundX,
                            spawningSecretRoom ? RoomConstants.RoomBorderY : RoomConstants.BackgroundY,
                            i, 
                            j - 1);
                    }
                }
                j++;
            }
        }

        private void SpawnFromString(string spawnType, int offsetX, int offsetY, int gridX, int gridY)
        {
            int posX = offsetX + gridX * RoomConstants.TileLength;
            int posY = offsetY + gridY * RoomConstants.TileLength;
            Point position = new Point(posX, posY);
            IBlock blockType;
            INpc npcType;
            IItem itemType;
            IBackground backgroundType;

            switch (spawnType)
            {
                //Blocks
                case RoomConstants.Block:
                    blockType = new Square(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.BrickTile:
                    blockType = new BrickTile(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.GapTile:
                    blockType = new GapTile(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.Fire:
                    position.X += RoomConstants.TileLength / 2;
                    blockType = new Fire(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.LadderTile:
                    backgroundType = new LadderTile(spriteBatch, position);
                    room.AllObjects.Spawn(backgroundType);
                    break;
                case RoomConstants.Stairs:
                    blockType = new Stairs(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.FishStatue:
                    blockType = new FishStatues(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.DragonStatue:
                    blockType = new DragonStatues(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.BlueGrass:
                    backgroundType = new TileBlueGrass(spriteBatch, position);
                    room.AllObjects.Spawn(backgroundType);
                    break;
                case RoomConstants.Water:
                    blockType = new TileWater(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.MovableBlock:
                    blockType = new MovableSquare(spriteBatch, position);
                    room.AddMovableSquare((MovableSquare)blockType);
                    room.AllObjects.Spawn(blockType);
                    break;

                //Npcs
                case RoomConstants.Aquamentus:
                    npcType = new Aquamentus(spriteBatch, position, room.AllObjects);
                    room.AllObjects.Spawn(npcType);
                    break;
                case RoomConstants.Bat:
                    npcType = new Bat(spriteBatch, position);
                    room.AllObjects.Spawn(npcType);
                    break;
                case RoomConstants.Goriya:
                    npcType = new Goriya(spriteBatch, position, room.AllObjects);
                    room.AllObjects.Spawn(npcType);
                    break;
                case RoomConstants.Hand:
                    npcType = new Hand(spriteBatch, position, ((RoomWallMaster)room).GetWallMasterRoomToJumpTo());
                    room.AllObjects.Spawn(npcType);
                    break;
                case RoomConstants.Jelly:
                    npcType = new Jelly(spriteBatch, position);
                    room.AllObjects.Spawn(npcType);
                    break;
                case RoomConstants.OldMan:
                    position.X += RoomConstants.TileLength / 2;
                    npcType = new OldMan(spriteBatch, position);
                    room.AllObjects.Spawn(npcType);
                    break;
                case RoomConstants.Skeleton:
                    npcType = new Skeleton(spriteBatch, position);
                    room.AllObjects.Spawn(npcType);
                    break;
                case RoomConstants.SpikeTrap:
                    npcType = new SpikeTrap(spriteBatch, position, room.AllObjects.GetPlayer(0));
                    room.AllObjects.Spawn(npcType);
                    break;

                //Items
                case RoomConstants.Compass:
                    itemType = new CompassItem(spriteBatch, position);
                    room.AllObjects.Spawn(itemType);
                    break;
                case RoomConstants.Heart:
                    position.X += (int)(4 * RoomConstants.SpriteMultiplier);
                    position.Y += (int)(4 * RoomConstants.SpriteMultiplier);
                    itemType = new HeartItem(spriteBatch, position);
                    room.AllObjects.Spawn(itemType);
                    break;
                case RoomConstants.Key:
                    itemType = new KeyItem(spriteBatch, position);
                    room.AllObjects.Spawn(itemType);
                    break;
                case RoomConstants.Map:
                    itemType = new MapItem(spriteBatch, position);
                    room.AllObjects.Spawn(itemType);
                    break;
                case RoomConstants.Triforce:
                    position.X += (int)(12 * RoomConstants.SpriteMultiplier);
                    position.Y += (int)(2 * RoomConstants.SpriteMultiplier);
                    itemType = new TriforceItem(spriteBatch, position);
                    room.AllObjects.Spawn(itemType);
                    break;
                case RoomConstants.HeartContainer:
                    itemType = new HeartContainerItem(spriteBatch, position);
                    room.AllObjects.Spawn(itemType);
                    break;
                case RoomConstants.Bow:
                    itemType = new BowItem(spriteBatch, position);
                    room.AllObjects.Spawn(itemType);
                    break;

                default:
                    break;

            }
        }

        private void SpawnWallsAndBackground(string spawnType, int i)
        {
            IBackground backgroundType;
            IBlock blockType;
            Point position;

            if (i == 0)
                position = new Point(RoomConstants.BackgroundX, RoomConstants.BackgroundY);
            else if (i == 1)
                position = new Point(RoomConstants.RoomBorderX, RoomConstants.RoomBorderY);
            else if (i == 2)
                position = new Point(RoomConstants.TopDoorX, RoomConstants.TopDoorY);
            else if (i == 3)
                position = new Point(RoomConstants.RightDoorX, RoomConstants.RightDoorY);
            else if (i == 4)
                position = new Point(RoomConstants.BottomDoorX, RoomConstants.BottomDoorY);
            else if (i == 5)
                position = new Point(RoomConstants.LeftDoorX, RoomConstants.LeftDoorY);
            else
                position = Point.Zero;

            switch (spawnType)
            {
                case RoomConstants.TileBackground:
                    backgroundType = new TileBackground(spriteBatch, position);
                    room.AllObjects.Spawn(backgroundType);
                    break;
                case RoomConstants.RoomBorder:
                    backgroundType = new RoomBorder(spriteBatch, position);
                    room.AllObjects.Spawn(backgroundType);
                    break;
                case RoomConstants.BlackBackground:
                    backgroundType = new BlackBackground(spriteBatch, position);
                    room.AllObjects.Spawn(backgroundType);
                    break;
                case RoomConstants.OldBackground:
                    backgroundType = new OldBackground(spriteBatch, position);
                    room.AllObjects.Spawn(backgroundType);
                    break;
                case RoomConstants.WallPiece:
                    blockType = new Walls(spriteBatch, position);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.OpenDoor:
                    blockType = new OpenedDoor(spriteBatch, position, room);
                    room.AddDoor((IDoor)blockType);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.LockedDoor:
                    blockType = new LockedDoor(spriteBatch, position, room);
                    room.AddDoor((IDoor)blockType);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.ShutDoor:
                    blockType = new ShutDoor(spriteBatch, position, room);
                    room.AddDoor((IDoor)blockType);
                    room.AllObjects.Spawn(blockType);
                    break;
                case RoomConstants.BombableWall:
                    blockType = new BombableOpening(spriteBatch, position, room);
                    room.AddDoor((IDoor)blockType);
                    room.AllObjects.Spawn(blockType);
                    break;
                default:
                    break;

            }

        }
    }
}

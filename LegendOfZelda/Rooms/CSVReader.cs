using LegendOfZelda.Enemies;
using LegendOfZelda.Environment;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms.RoomImplementation;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    internal static class CSVReader
    {

        public static IRoom GetRoomFromFile(SpriteBatch spriteBatch, string fileName, List<IPlayer> playerList)
        {
            IRoom room = null;
            bool spawningLargeRoom = false;
            TextFieldParser parser = new TextFieldParser(fileName)
            {
                Delimiters = new string[] { "," } //Delimiters are like separators in NextWordOrSeparator
            };
            int j = 0;
            //Read each line of the file
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                int i;
                switch (j)
                {
                    case 0: // set room metadata
                        room = GetRoomFromString(fields[0], spriteBatch, playerList);
                        room.RoomId = fields[1];
                        room.LocationOnMap = new Point(int.Parse(fields[2]), int.Parse(fields[3]));
                        break;
                    case 1: // spawn walls and border
                        spawningLargeRoom = string.Equals("large", fields[0]);
                        i = 1;
                        SpawnBackgroundAndBorder(spriteBatch, room, fields[i], i++);
                        SpawnBackgroundAndBorder(spriteBatch, room, fields[i], i++);
                        break;
                    case 2:
                        i = 0;
                        room.AddRoomConnection(Constants.Direction.Up, fields[i++]);
                        room.AddRoomConnection(Constants.Direction.Right, fields[i++]);
                        room.AddRoomConnection(Constants.Direction.Down, fields[i++]);
                        room.AddRoomConnection(Constants.Direction.Left, fields[i++]);
                        room.AddRoomConnection(Constants.Direction.Stairs, fields[i]);
                        break;
                    case 3:
                        for(i = 0; i < 4; i++) SpawnWalls(spriteBatch, room, fields[i], i);
                        break;
                    default:
                        for (i = 0; i < fields.Length; i++)
                        {
                            SpawnFromString(room,
                                spriteBatch,
                                fields[i],
                                spawningLargeRoom ? RoomConstants.RoomBorderX : RoomConstants.BackgroundX,
                                spawningLargeRoom ? RoomConstants.RoomBorderY : RoomConstants.BackgroundY,
                                i,
                                j - 4);
                        }
                        break;
                }
                j++;
            }

            return room;
        }

        private static void SpawnFromString(IRoom room, SpriteBatch spriteBatch, string spawnType, int offsetX, int offsetY, int gridX, int gridY)
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
                    ((RoomWithMovableSquare)room).AddMovableSquare((MovableSquare)blockType);
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

        private static void SpawnBackgroundAndBorder(SpriteBatch spriteBatch, IRoom room, string spawnType, int i)
        {
            IBackground backgroundType;
            Point position;

            if (i == 1)
                position = new Point(RoomConstants.BackgroundX, RoomConstants.BackgroundY);
            else if (i == 2)
                position = new Point(RoomConstants.RoomBorderX, RoomConstants.RoomBorderY);
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
                default:
                    break;

            }

        }

        private static void SpawnWalls(SpriteBatch spriteBatch, IRoom room, string spawnType, int i)
        {
            IBlock blockType;
            Point position;

            if (i == 0)
                position = new Point(RoomConstants.TopDoorX, RoomConstants.TopDoorY);
            else if (i == 1)
                position = new Point(RoomConstants.RightDoorX, RoomConstants.RightDoorY);
            else if (i == 2)
                position = new Point(RoomConstants.BottomDoorX, RoomConstants.BottomDoorY);
            else if (i == 3)
                position = new Point(RoomConstants.LeftDoorX, RoomConstants.LeftDoorY);
            else
                position = Point.Zero;

            switch (spawnType)
            {
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

        private static IRoom GetRoomFromString(string roomType, SpriteBatch spriteBatch, List<IPlayer> playerList)
        {
            switch (roomType)
            {
                case "roomNormal":
                    return new Room(playerList);
                case "roomPushableSquare":
                    return new RoomWithMovableSquare(playerList);
                case "room5":
                    return new Room5(playerList);
                case "roomAquamentus":
                    return new RoomAquamentus(playerList);
                case "roomBeforeSecretRoom":
                    return new RoomBeforeSecretRoom(playerList);
                case "roomSecret":
                    return new SecretRoom(playerList);
                case "roomWallMaster":
                    return new RoomWallMaster(spriteBatch, playerList);
                default:
                    return null;
            }
        }
    }
}

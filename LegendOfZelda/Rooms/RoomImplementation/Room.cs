using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class Room : IRoom
    {
        private readonly Dictionary<Constants.Direction, IRoom> roomDictionary;
        private readonly Dictionary<Constants.Direction, IDoor> roomDoors;
        private readonly CollisionManager collisionManager;
        private MovableSquare movableSquare;

        public bool Visiting { get; set; }
        public int RoomType { get; private set; }
        public Point LocationOnMap { get; set; }
        public ISpawnableManager AllObjects { get; private set; }
        public List<IPlayer> PlayerList { get => AllObjects.PlayerList; }
        public RoomMap RoomMap { get; private set; }

        public Room(SpriteBatch spriteBatch, string fileName, List<IPlayer> playerList)
        {
            AllObjects = new SpawnableManager(playerList);
            roomDictionary = new Dictionary<Constants.Direction, IRoom>();
            roomDoors = new Dictionary<Constants.Direction, IDoor>();
            new CSVReader(spriteBatch, this, fileName);
            collisionManager = new CollisionManager(AllObjects);
            LocationOnMap = new Point(-1, -1);
            RoomType = 0;
            Visiting = false;
            SpawnWalls();
        }

        public virtual void Draw()
        {
            AllObjects.DrawAll();
        }

        public virtual void Update()
        {
            AllObjects.UpdateAll();
            collisionManager.CheckAndHandleAllCollisions();
        }

        public bool ConnectRoom(IRoom newRoom, Constants.Direction direction)
        {
            // connects a room each way - returning true if successful, else false
            Constants.Direction invertedDirection = UtilityMethods.InvertDirection(direction);
            if (GetRoom(direction) == null || newRoom.GetRoom(invertedDirection) == null)
            {
                UpdateRoomType(direction);
                roomDictionary[direction] = newRoom; // add room connection one way
                return newRoom.ConnectRoom(this, invertedDirection); // add room connection in the opposite 
            }

            return false;
        }

        private void UpdateRoomType(Constants.Direction direction)
        {
            switch (direction)
            {
                case Constants.Direction.Up:
                    RoomType += 0b1000;
                    return;
                case Constants.Direction.Right:
                    RoomType += 0b100;
                    return;
                case Constants.Direction.Down:
                    RoomType += 0b10;
                    return;
                case Constants.Direction.Left:
                    RoomType += 0b1;
                    return;
            }
        }

        public IRoom GetRoom(Constants.Direction direction)
        {
            return roomDictionary.ContainsKey(direction) ? roomDictionary[direction] : null;
        }

        private void SpawnWalls()
        {
            AllObjects.Spawn(new RoomWall(RoomConstants.LeftUpWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.LeftDownWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.DownLeftWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.DownRightWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.RightDownWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.RightUpWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.UpRightWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.UpLeftWallRectangle));

            AllObjects.Spawn(new RoomChangeTrigger(Constants.Direction.Down));
            AllObjects.Spawn(new RoomChangeTrigger(Constants.Direction.Right));
            AllObjects.Spawn(new RoomChangeTrigger(Constants.Direction.Left));
            AllObjects.Spawn(new RoomChangeTrigger(Constants.Direction.Up));

        }

        public virtual void ResetRoom()
        {
            AllObjects.ResetClouds();
            if (movableSquare != null) movableSquare.RoomReset();
        }

        public void AddDoor(IDoor door)
        {
            roomDoors.Add(door.Side, door);
        }

        public IDoor GetDoor(Constants.Direction side)
        {
            return roomDoors.ContainsKey(side) ? roomDoors[side] : null;
        }

        public void AddMovableSquare(MovableSquare square)
        {
            movableSquare = square;
        }
    }
}

using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class Room : IRoom
    {
        protected Dictionary<Constants.Direction, IRoom> roomDictionary;
        protected Dictionary<Constants.Direction, IDoor> roomDoors;
        protected Dictionary<Constants.Direction, string> roomConnectionStrings;
        protected CollisionManager collisionManager;

        public string RoomId { get; set; }
        public bool Visiting { get; set; }
        public int RoomType { get; protected set; }
        public Point LocationOnMap { get; set; }
        public ISpawnableManager AllObjects { get; protected set; }
        public List<IPlayer> PlayerList { get => AllObjects.PlayerList; }
        public RoomMap RoomMap { get; private set; }

        protected Room() { }

        public Room(List<IPlayer> playerList)
        {
            AllObjects = new SpawnableManager(playerList);

            roomDictionary = new Dictionary<Constants.Direction, IRoom>();
            roomDoors = new Dictionary<Constants.Direction, IDoor>();
            roomConnectionStrings = new Dictionary<Constants.Direction, string>();

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

        public virtual void ClockUpdate()
        {
            AllObjects.ClockUpdateAll();
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

        public virtual IRoom GetRoom(Constants.Direction direction)
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
        }

        public void AddDoor(IDoor door)
        {
            roomDoors.Add(door.Side, door);
        }

        public IDoor GetDoor(Constants.Direction side)
        {
            return roomDoors.ContainsKey(side) ? roomDoors[side] : null;
        }


        public virtual void FinalizeRoomConnections(Dictionary<string, IRoom> roomIdToRoomDictionary)
        {
            foreach (KeyValuePair<Constants.Direction, string> keyValuePair in roomConnectionStrings)
            {
                ConnectRoom(roomIdToRoomDictionary[keyValuePair.Value], keyValuePair.Key);
            }
        }

        public void AddRoomConnection(Constants.Direction direction, string roomId)
        {
            if (string.Equals("", roomId)) return;
            roomConnectionStrings.Add(direction, roomId);
        }

        public virtual void RunRoomEntryProcedure()
        {
        }

        public virtual void RunRoomExitProcedure()
        {
            foreach (IProjectile projectile in AllObjects.ProjectileList) projectile.Despawn();
            AllObjects.ProjectileList.Clear();
        }
    }
}

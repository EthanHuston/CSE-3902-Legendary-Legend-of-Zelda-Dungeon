using LegendOfZelda.Enemies;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomWallMaster : RoomBeforeBoss
    {
        private const string roomIdToJumpTo = "startRoom";
        private const int wallMasterSpawnDelay = 80;
        private int wallMasterCounter = 3;
        private const int wallMasterToSpawn = 12;
        private int spawnDelayCounter;
        private IRoom roomToJumpTo;
        private readonly SpriteBatch spriteBatch;
        private readonly Random rand;
        private const int up = 0, right = 1, down = 2;

        public RoomWallMaster(SpriteBatch spriteBatch, List<IPlayer> playerList) : base(playerList)
        {
            this.spriteBatch = spriteBatch;
            rand = RoomConstants.RandomGenerator;
            wallMasterCounter = 3;
        }

        public void AddRoomToJumpTo(IRoom roomToJumpTo)
        {
            this.roomToJumpTo = roomToJumpTo;
        }

        public override void Update()
        {
            spawnDelayCounter++;
            if (spawnDelayCounter >= wallMasterSpawnDelay && wallMasterCounter <= wallMasterToSpawn)
            {
                AllObjects.Spawn(new Hand(spriteBatch, GenerateRandomWallMasterSpawnPoint(), roomToJumpTo));
                spawnDelayCounter = 0;
                wallMasterCounter++;
            }
            base.Update();
        }

        private Point GenerateRandomWallMasterSpawnPoint()
        {
            Point position = new Point();
            int direction = rand.Next(up, down + 1);
            if (direction == up || direction == down)
            {
                position.X = rand.Next(Constants.HandUpDownMinX, Constants.HandUpDownMaxX);
                position.Y = direction == up ? Constants.HandSpawnUpY : Constants.HandSpawnDownY;
            }
            else // left or right
            {
                position.X = direction == right ? Constants.HandSpawnRightX : Constants.HandSpawnLeftX;
                position.Y = rand.Next(Constants.HandLeftRightMinY, Constants.HandLeftRightMaxY);
            }
            return position;
        }

        public IRoom GetWallMasterRoomToJumpTo()
        {
            return roomToJumpTo;
        }

        public override void ResetRoom()
        {
            AllObjects.NpcList.Clear();
            SpawnInitialWallMaster();
            base.ResetRoom();
        }

        public override void FinalizeRoomConnections(Dictionary<string, IRoom> roomIdToRoomDictionary)
        {
            roomToJumpTo = roomIdToRoomDictionary[roomIdToJumpTo];
            base.FinalizeRoomConnections(roomIdToRoomDictionary);
        }

        private void SpawnInitialWallMaster()
        {
            for (int i = 0; i < wallMasterCounter; i++) AllObjects.Spawn(new Hand(spriteBatch, GenerateRandomWallMasterSpawnPoint(), roomToJumpTo));
        }
    }
}

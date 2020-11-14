using LegendOfZelda.Enemies;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomWallMaster : Room
    {
        private const int wallMasterSpawnDelay = 20;
        private int spawnDelayCounter;
        private readonly IRoom roomToJumpTo;
        private readonly SpriteBatch spriteBatch;
        private readonly Random rand;
        private const int up = 0, right = 1, down = 2, left = 3;

        public RoomWallMaster(SpriteBatch spriteBatch, string filename, List<IPlayer> playerList, IRoom roomToJumpTo) : base(spriteBatch, filename, playerList)
        {
            spawnDelayCounter = 20;
            this.spriteBatch = spriteBatch;
            rand = RoomConstants.RandomGenerator;
            this.roomToJumpTo = roomToJumpTo;
        }

        public override void Update()
        {
            spawnDelayCounter++;
            if (spawnDelayCounter >= wallMasterSpawnDelay)
            {
                AllObjects.Spawn(new Hand(spriteBatch, GenerateRandomWallMasterSpawnPoint(), roomToJumpTo));
                spawnDelayCounter = 0;
            }
            base.Update();
        }

        private Point GenerateRandomWallMasterSpawnPoint()
        {
            Point position = new Point();
            int direction = rand.Next(up, left);
            if(direction == up || direction == down)
            {
                position.X = rand.Next(RoomConstants.WallWidth, RoomConstants.RoomWidth - RoomConstants.WallWidth);
                position.Y = direction == up ? Constants.MinYPos - RoomConstants.WallWidth : Constants.MaxYPos;
            } else
            {
                position.X = direction == right ? Constants.MinXPos - RoomConstants.WallWidth : Constants.MaxXPos;
                position.Y = rand.Next(Constants.MinYPos + RoomConstants.WallWidth, Constants.MaxYPos - RoomConstants.WallWidth);
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
            base.ResetRoom();
        }
    }
}

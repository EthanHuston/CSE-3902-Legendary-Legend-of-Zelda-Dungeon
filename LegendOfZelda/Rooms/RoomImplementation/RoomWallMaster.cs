using LegendOfZelda.Enemies;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomWallMaster : Room
    {
        private const int wallMasterMaxCount = 10;
        private readonly IRoom roomToJumpTo;
        private readonly SpriteBatch spriteBatch;
        private readonly Random rand;
        private const int up = 0, right = 1, down = 2, left = 3;

        public RoomWallMaster(SpriteBatch spriteBatch, string filename, List<IPlayer> playerList, IRoom roomToJumpTo) : base(spriteBatch, filename, playerList)
        {
            this.spriteBatch = spriteBatch;
            rand = RoomConstants.RandomGenerator;
            this.roomToJumpTo = roomToJumpTo;
        }

        public override void Update()
        {
            if (AllObjects.NpcList.Count < wallMasterMaxCount)
            {
                AllObjects.Spawn(new Hand(spriteBatch, GenerateRandomWallMasterSpawnPoint(), roomToJumpTo));
            }
            base.Update();
        }

        private Point GenerateRandomWallMasterSpawnPoint()
        {
            Point position = new Point();
            int direction = rand.Next(up, left + 1);
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
            base.ResetRoom();
        }
    }
}

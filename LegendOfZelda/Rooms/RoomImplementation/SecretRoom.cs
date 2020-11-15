using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class SecretRoom : Room
    {
        public SecretRoom(SpriteBatch spriteBatch, string filename, List<IPlayer> playerList)
        {
            AllObjects = new SpawnableManager(playerList);
            roomDictionary = new Dictionary<Constants.Direction, IRoom>();
            roomDoors = new Dictionary<Constants.Direction, IDoor>();
            new CSVReader(spriteBatch, this, filename);
            collisionManager = new CollisionManager(AllObjects);
            LocationOnMap = new Point(-1, -1);
            RoomType = 0;
            Visiting = false;
            SpawnWalls();
        }

        public override IRoom GetRoom(Constants.Direction direction)
        {
            if (direction == Constants.Direction.Stairs) UpdatePlayerPositions();
            return base.GetRoom(direction);
        }

        private void UpdatePlayerPositions()
        {
            foreach (IPlayer player in AllObjects.PlayerList) player.Position = LinkConstants.SecretRoomExitSpawnPosition;
        }

        private void SpawnWalls()
        {
            AllObjects.Spawn(new RoomWall(RoomConstants.LeftWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.MiddleWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.RightWallRectangle));
            AllObjects.Spawn(new RoomWall(RoomConstants.TopWallRectangle));

            AllObjects.Spawn(new RoomChangeTrigger(Constants.Direction.Stairs, RoomConstants.SecretRoomRoomChangeTrigger));
        }

    }
}

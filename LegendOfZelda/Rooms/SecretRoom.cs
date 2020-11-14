using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
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

        private void SpawnWalls()
        {

        }
            
    }
}

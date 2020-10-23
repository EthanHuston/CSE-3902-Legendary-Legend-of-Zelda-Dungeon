using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    public class Room
    {
        private CSVReader csvReader;
        private ISpawnableManager allObjects;
        private Dictionary<Constants.Direction, Room> roomDictionary;

        public Room(SpriteBatch spriteBatch, string fileName)
        {
            allObjects = new SpawnableManager();
            csvReader = new CSVReader(spriteBatch, allObjects, fileName);
            roomDictionary = new Dictionary<Constants.Direction, Room>();
        }

        public void Draw()
        {
            allObjects.DrawAll();
        }

        public void Update()
        {
            allObjects.UpdateAll();
        }

        public ISpawnableManager GetSpawnableManager()
        {
            return allObjects;
        }

        public void AddRoom(Room newRoom, Constants.Direction direction)
        {
            if (!roomDictionary.ContainsKey(direction)) roomDictionary[direction] = newRoom;
        }
    }
}

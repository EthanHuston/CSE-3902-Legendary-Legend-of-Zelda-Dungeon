using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    public class Room
    {
        private Dictionary<Constants.Direction, Room> roomDictionary;

        public ISpawnableManager AllObjects { get; private set; }
        public List<IPlayer> PlayerList { get => AllObjects.PlayerList; }

        public Room(SpriteBatch spriteBatch, string fileName, List<IPlayer> playerList)
        {
            AllObjects = new SpawnableManager(playerList);
            CSVReader csvReader = new CSVReader(spriteBatch, AllObjects, fileName);
            roomDictionary = new Dictionary<Constants.Direction, Room>();
        }

        public void Draw()
        {
            AllObjects.DrawAll();
        }

        public void Update()
        {
            AllObjects.UpdateAll();
        }

        public bool ConnectRoom(Room newRoom, Constants.Direction direction)
        {
            // connects a room each way - returning true if successful, else false
            Constants.Direction invertedDirection = UtilityMethods.InvertDirection(direction);
            if (GetRoom(direction) == null && newRoom.GetRoom(invertedDirection) == null) {
                roomDictionary[direction] = newRoom; // add room connection one way
                return newRoom.ConnectRoom(this, invertedDirection); // add room connection in the opposite 
            }

            return false;
        }

        public Room GetRoom(Constants.Direction direction)
        {
            return roomDictionary.ContainsKey(direction) ? roomDictionary[direction] : null;
        }
    }
}

using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace LegendOfZelda.Rooms
{
    internal static class RoomFactory
    {
        private const string startingRoomId = "startRoom";
        private const string roomDataDirectory = "Content\\RoomData\\";

        public static IRoom BuildMapAndGetStartRoom(SpriteBatch spriteBatch, List<IPlayer> playerList)
        {
            Dictionary<string, IRoom> roomDictionary = new Dictionary<string, IRoom>();
            InitRoomsDictionary(roomDictionary, spriteBatch, playerList);
            ConnectRooms(roomDictionary);
            return roomDictionary[startingRoomId];
        }

        private static void InitRoomsDictionary(Dictionary<string, IRoom> roomDictionary, SpriteBatch spriteBatch, List<IPlayer> playerList)
        {
            string[] roomFiles = Directory.GetFiles(roomDataDirectory);
            foreach (string filename in roomFiles)
            {
                IRoom newRoom = CSVReader.GetRoomFromFile(spriteBatch, filename, playerList);
                roomDictionary.Add(newRoom.RoomId, newRoom);
            }
        }

        private static void ConnectRooms(Dictionary<string, IRoom> roomDictionary)
        {
            foreach (KeyValuePair<string, IRoom> keyValuePair in roomDictionary) keyValuePair.Value.FinalizeRoomConnections(roomDictionary);
        }
    }
}

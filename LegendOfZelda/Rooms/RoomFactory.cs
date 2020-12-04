using LegendOfZelda.Link.Interface;
using System.Collections.Generic;
using System.IO;

namespace LegendOfZelda.Rooms
{
    internal static class RoomFactory
    {
        private const string startingRoomId = "startRoom";
        private const string roomDataDirectory = "Content\\RoomData\\";

        public static IRoom BuildMapAndGetStartRoom(Game1 game, List<IPlayer> playerList)
        {
            Dictionary<string, IRoom> roomDictionary = new Dictionary<string, IRoom>();
            InitRoomsDictionary(roomDictionary, game, playerList);
            ConnectRooms(roomDictionary);
            return roomDictionary[startingRoomId];
        }

        private static void InitRoomsDictionary(Dictionary<string, IRoom> roomDictionary, Game1 game, List<IPlayer> playerList)
        {
            string[] roomFiles = Directory.GetFiles(roomDataDirectory);
            foreach (string filename in roomFiles)
            {
                IRoom newRoom = CSVReader.GetRoomFromFile(game, filename, playerList);
                roomDictionary.Add(newRoom.RoomId, newRoom);
            }
        }

        private static void ConnectRooms(Dictionary<string, IRoom> roomDictionary)
        {
            foreach (KeyValuePair<string, IRoom> keyValuePair in roomDictionary) keyValuePair.Value.FinalizeRoomConnections(roomDictionary);
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomFactory
    {
        private readonly Room startingRoom;
        private List<Room> roomsList;

        public RoomFactory(SpriteBatch spriteBatch, string startingRoomName) {
            roomsList = new List<Room>();
            InitRoomsList(spriteBatch);
            ConnectRooms();
        }

        private void InitRoomsList(SpriteBatch spriteBatch)
        {
            roomsList.Add(null); // room files start at 1
            for(int i = 1; i <= RoomConstants.NumberRooms; i++)
            {
                roomsList.Add(new Room(spriteBatch, "Room" + i + ".csv"));
            }
        }

        private void ConnectRooms()
        {
            // Row 1
            roomsList[1].AddRoom(roomsList[2], Constants.Direction.Right); // connect 1<->2
            roomsList[2].AddRoom(roomsList[3], Constants.Direction.Right); // connect 2<->3

            // Row 2
            roomsList[5].AddRoom(roomsList[6], Constants.Direction.Right);
            roomsList[6].AddRoom(roomsList[7], Constants.Direction.Right);

            // Row 3
            roomsList[8].AddRoom(roomsList[9], Constants.Direction.Right);
            roomsList[9].AddRoom(roomsList[10], Constants.Direction.Right);

            // Row 4

        }
    }
}

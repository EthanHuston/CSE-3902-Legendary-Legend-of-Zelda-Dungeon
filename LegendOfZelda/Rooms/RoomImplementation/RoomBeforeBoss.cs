using System.Collections.Generic;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomBeforeBoss : Room
    {
        private const string bossRoomName = "room14";
        private IRoom bossRoom;

        public RoomBeforeBoss(List<IPlayer> playerList) : base(playerList)
        {
        }

        public override void RunRoomEntryProcedure()
        {
            if(bossRoom.AllObjects.NpcList.Count > 0)
            {
                // TODO: play cool sound
            }
        }

        public override void FinalizeRoomConnections(Dictionary<string, IRoom> roomIdToRoomDictionary)
        {
            bossRoom = roomIdToRoomDictionary[bossRoomName];
            base.FinalizeRoomConnections(roomIdToRoomDictionary);
        }
    }
}

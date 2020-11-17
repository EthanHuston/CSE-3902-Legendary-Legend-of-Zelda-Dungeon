using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class RoomBeforeBoss : Room
    {
        private const string bossRoomName = "room14";
        private IRoom bossRoom;

        public RoomBeforeBoss(List<IPlayer> playerList) : base(playerList)
        {
        }

        public override void RunRoomEntryProcedure()
        {
            if (bossRoom.AllObjects.NpcList.Count > 0)
            {
                SoundFactory.Instance.CreateBossScreamSound().Play();
            }
        }

        public override void FinalizeRoomConnections(Dictionary<string, IRoom> roomIdToRoomDictionary)
        {
            bossRoom = roomIdToRoomDictionary[bossRoomName];
            base.FinalizeRoomConnections(roomIdToRoomDictionary);
        }
    }
}

using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    interface IRoom
    {
        string RoomId { get; set; }
        bool Visiting { get; set; }
        int RoomType { get; }
        Point LocationOnMap { get; set; }
        ISpawnableManager AllObjects { get; }
        List<IPlayer> PlayerList { get; }
        RoomMap RoomMap { get; }

        void Draw();

        void Update();
        void ClockUpdate();
        bool ConnectRoom(IRoom newRoom, Constants.Direction direction);
        void AddRoomConnection(Constants.Direction direction, string roomId);
        IRoom GetRoom(Constants.Direction direction);
        void ResetRoom();
        void AddDoor(IDoor door);
        IDoor GetDoor(Constants.Direction side);
        void FinalizeRoomConnections(Dictionary<string, IRoom> roomIdToRoomDictionary);
        void RunRoomEntryProcedure();
        void RunRoomExitProcedure();
    }
}

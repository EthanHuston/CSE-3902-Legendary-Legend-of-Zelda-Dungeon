using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    interface IRoom
    {
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

        IRoom GetRoom(Constants.Direction direction);

        void ResetRoom();

        void AddDoor(IDoor door);

        IDoor GetDoor(Constants.Direction side);
    }
}

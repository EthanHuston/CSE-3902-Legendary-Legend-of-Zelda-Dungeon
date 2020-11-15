﻿using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Rooms.RoomImplementation;

namespace LegendOfZelda.Environment
{
    interface IDoor : IBlock
    {
        Constants.Direction Side { get; }
        bool IsOpen { get; }
        void OpenDoor();
        void CloseDoor();
        IRoom Location { get; }
    }
}

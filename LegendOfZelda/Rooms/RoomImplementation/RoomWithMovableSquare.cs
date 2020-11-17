using LegendOfZelda.Environment;
using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class RoomWithMovableSquare : Room
    {
        protected MovableSquare movableSquare;

        public RoomWithMovableSquare(List<IPlayer> playerList) : base(playerList)
        {

        }

        public override void ResetRoom()
        {
            if (movableSquare != null) movableSquare.RoomReset();
            base.ResetRoom();
        }

        public void AddMovableSquare(MovableSquare square)
        {
            movableSquare = square;
        }
    }
}

using LegendOfZelda.Environment;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomWithMovableSquare : Room
    {
        protected MovableSquare movableSquare;

        public RoomWithMovableSquare(SpriteBatch spriteBatch, string fileName, List<IPlayer> playerList) : base(spriteBatch, fileName, playerList)
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

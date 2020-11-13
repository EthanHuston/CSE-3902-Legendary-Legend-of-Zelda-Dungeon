using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomAquamentus : Room
    {
        bool openedDoor;
        public RoomAquamentus(SpriteBatch spriteBatch, string fileName, List<IPlayer> playerList) : base(spriteBatch, fileName, playerList)
        {
            openedDoor = false;
        }


        public override void Update()
        {
            if (!openedDoor && AllObjects.NpcList.Count == 0)
            {
                GetDoor(Constants.Direction.Right).OpenDoor();
                openedDoor = true;
            }
            base.Update();
        }
    }
}

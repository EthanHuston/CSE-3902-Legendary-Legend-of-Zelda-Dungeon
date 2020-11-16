using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class Room5 : Room
    {
        private bool doorHasBeenClosed;
        private bool doorHasBeenOpened;
        public Room5(List<IPlayer> playerList) : base(playerList)
        {
            doorHasBeenClosed = false;
            doorHasBeenOpened = false;
        }

        public override void Update()
        {
            if (!doorHasBeenClosed && SafeToCloseDoor())
            {
                GetDoor(Constants.Direction.Right).CloseDoor();
                doorHasBeenClosed = true;
            }
            if (doorHasBeenClosed && !doorHasBeenOpened && AllObjects.NpcList.Count <= 0)
            {
                GetDoor(Constants.Direction.Right).OpenDoor();
                doorHasBeenOpened = true;
            }
            base.Update();
        }

        private bool SafeToCloseDoor()
        {
            foreach (IPlayer player in PlayerList)
            {
                if (player.Position.X >= RoomConstants.RightDoorX - player.GetRectangle().Width)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

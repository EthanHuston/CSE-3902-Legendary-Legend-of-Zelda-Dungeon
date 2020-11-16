using LegendOfZelda.Environment;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomKillAllEnemies : Room
    {
        private bool doorHasBeenClosed;
        private bool doorHasBeenOpened;
        public RoomKillAllEnemies(List<IPlayer> playerList) : base(playerList)
        {
            doorHasBeenClosed = false;
            doorHasBeenOpened = false;
        }

        public override void Update()
        {
            if (!doorHasBeenClosed && SafeToCloseDoor())
            {
                foreach (KeyValuePair<Constants.Direction, IDoor> keyValuePair in roomDoors) GetDoor(keyValuePair.Key).CloseDoor();
                doorHasBeenClosed = true;
            }
            if (doorHasBeenClosed && !doorHasBeenOpened && AllObjects.NpcList.Count <= 0)
            {
                foreach (KeyValuePair<Constants.Direction, IDoor> keyValuePair in roomDoors)
                {
                    if ((keyValuePair.Value.GetType() == typeof(LockedDoor) ||
                           keyValuePair.Value.GetType() == typeof(BombableOpening)) && 
                        !keyValuePair.Value.IsOpen
                        ) continue;
                    GetDoor(keyValuePair.Key).OpenDoor();
                }
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

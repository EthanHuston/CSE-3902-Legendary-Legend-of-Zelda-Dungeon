using LegendOfZelda.Environment;
using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class RoomKillAllEnemies : Room
    {
        private bool doorHasBeenClosed;
        private bool doorHasBeenOpened;
        private readonly Dictionary<Constants.Direction, IDoor> openDoorsDictionary;

        public RoomKillAllEnemies(List<IPlayer> playerList, Game1 game) : base(playerList, game)
        {
            doorHasBeenClosed = false;
            doorHasBeenOpened = false;
            openDoorsDictionary = new Dictionary<Constants.Direction, IDoor>();
        }

        public override void Update()
        {
            if (!doorHasBeenClosed && SafeToCloseDoor())
            {
                foreach (KeyValuePair<Constants.Direction, IDoor> keyValuePair in roomDoors) { 
                    if(keyValuePair.Value.IsOpen)
                    {
                        openDoorsDictionary.Add(keyValuePair.Key, keyValuePair.Value);
                        keyValuePair.Value.CloseDoor();
                    }
                }
                doorHasBeenClosed = true;
            }
            if (doorHasBeenClosed && !doorHasBeenOpened && AllObjects.NpcList.Count <= 0)
            {
                foreach (KeyValuePair<Constants.Direction, IDoor> keyValuePair in openDoorsDictionary)
                {
                    keyValuePair.Value.OpenDoor();
                }
                doorHasBeenOpened = true;
            }
            base.Update();
        }

        private bool SafeToCloseDoor()
        {
            foreach (IPlayer player in PlayerList)
            {
                if (player.Position.X >= RoomConstants.RightDoorX - player.GetRectangle().Width || player.Position.Y < RoomConstants.TopDoorY + RoomConstants.WallWidth)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

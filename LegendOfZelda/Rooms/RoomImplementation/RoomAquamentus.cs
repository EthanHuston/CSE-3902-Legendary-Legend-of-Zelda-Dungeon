using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class RoomAquamentus : Room
    {
        private bool openedDoor;
        private readonly IItem heartContainer;

        public RoomAquamentus(List<IPlayer> playerList) : base(playerList)
        {
            openedDoor = false;
            heartContainer = RemoveHeartContainerFromSpawnList();
        }


        public override void Update()
        {
            if (!openedDoor && AllObjects.NpcList.Count == 0)
            {
                GetDoor(Constants.Direction.Right).OpenDoor();
                openedDoor = true;
                if (heartContainer != null) AllObjects.Spawn(heartContainer);
            }
            base.Update();
        }

        private IItem RemoveHeartContainerFromSpawnList()
        {
            IItem item;
            for (int i = 0; i < AllObjects.ItemList.Count; i++)
            {
                item = AllObjects.ItemList[i];
                if (item.GetType() == typeof(HeartContainerItem))
                {
                    AllObjects.ItemList.RemoveAt(i);
                    return item;
                }
            }
            return null;
        }
    }
}

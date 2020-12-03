using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class RoomWithKey : Room
    {
        private IItem key;
        private bool spawnedKey;

        public RoomWithKey(List<IPlayer> playerList, Game1 game) : base(playerList, game)
        {
            spawnedKey = false;
            key = null;
        }

        public override void Update()
        {
            if (!spawnedKey && AllObjects.NpcList.Count == 0 && key != null)
            {
                AllObjects.Spawn(key);
                spawnedKey = true;
            }

            base.Update();
        }

        private void RemoveKeyFromRoom()
        {
            int keyIndex = -1;
            for (int i = 0; i < AllObjects.ItemList.Count; i++)
            {
                if (typeof(KeyItem) == AllObjects.ItemList[i].GetType())
                {
                    keyIndex = i;
                    break;
                }
            }

            if (keyIndex == -1) return;

            key = AllObjects.ItemList[keyIndex];
            AllObjects.ItemList.RemoveAt(keyIndex);
        }

        public override void RunRoomEntryProcedure()
        {
            if (!spawnedKey) RemoveKeyFromRoom();
        }
    }
}

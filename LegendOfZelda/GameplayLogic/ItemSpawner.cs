using LegendOfZelda.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.GameplayLogic
{
    class ItemSpawner : IItemSpawner
    {
        private List<List<ISpawnable>> spawnableList;
        private List<IItem> itemList;
        private List<IProjectile> projectileList;
        private List<INpc> npcList;
        private List<IBlock> blockList;
        private List<IPlayer> playerList;

        public ItemSpawner()
        {
            itemList = new List<IItem>();
            projectileList = new List<IProjectile>();
            npcList = new List<INpc>();
            blockList = new List<IBlock>();
            playerList = new List<IPlayer>();
        }

        public void Spawn(INpc spawnable)
        {
            npcList.Add(spawnable);
        }

        public void Spawn(IItem spawnable)
        {
            itemList.Add(spawnable);
        }

        public void Spawn(IProjectile spawnable)
        {
            projectileList.Add(spawnable);
        }

        public void Spawn(IBlock spawnable)
        {
            blockList.Add(spawnable);
        }

        public void Spawn(IPlayer spawnable)
        {
            playerList.Add(spawnable);
        }

        public void DrawAll()
        {
            DrawList(blockList);
            DrawList(playerList);
            DrawList(npcList);
            DrawList(itemList);
            DrawList(projectileList);
        }

        private void DrawList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                ISpawnable spawnable = (ISpawnable)list[i];
                spawnable.Draw();
            }
        }

        public void UpdateAll()
        {
            UpdateList(blockList);
            UpdateList(playerList);
            UpdateList(npcList);
            UpdateList(itemList);
            UpdateList(projectileList);
        }

        private void UpdateList<T>(List<T> list)
        {
            List<int> indicesToRemove = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                ISpawnable item = (ISpawnable) list[i];
                item.Update();
                if (item.SafeToDespawn())
                {
                    indicesToRemove.Add(i);
                }
            }

            for (int i = 0; i < indicesToRemove.Count; i++)
            {
                list.RemoveAt(indicesToRemove[i]);
            }
        }
    }
}

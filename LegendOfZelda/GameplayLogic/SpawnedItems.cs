using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Link.Items
{
    class SpawnedItems : ISpawnedItems
    {
        private List<IItem> itemList;
        private List<IProjectile> projectileList;
        private List<INpc> npcList;
        private List<IBlock> blockList;
        private List<IPlayer> playerList;

        public SpawnedItems()
        {
            itemList = new List<ISpawnedItems>();
            projectileList = new List<IProjectile>();
            npcList = new List<INpc>();
            blockList = new List<IBlock>();
            playerList = new List<IPlayer>();
        }

        public void SpawnNewSpawnable(ISpawnable spawnable)
        {
            Spawn(spawnable);
        }

        public void DrawAll()
        {
            DrawList(blockList);
            DrawList(playerList);
            DrawList(npcList);
            DrawList(itemList);
            DrawList(projectileList);
        }

        private void DrawList(List<ISpawnable> list)
        {
            foreach (ISpawnable element in List)
            {
                element.Draw();
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

        private void UpdateList(List<ISpawnable> list)
        {
            List<int> indicesToRemove = new List<int>();
            for (int i = 0; i < spawnedItemList.Count; i++)
            {
                ILinkItem item = spawnedItemList[i];
                item.Update();
                if (item.SafeToDespawn())
                {
                    indicesToRemove.Add(i);
                }
            }

            for (int i = 0; i < indicesToRemove.Count; i++)
            {
                spawnedItemList.RemoveAt(indicesToRemove[i]);
            }
        }

        private void Spawn(INpc spawnable)
        {
            npcList.Add(spawnable);
        }

        private void Spawn(IItem spawnable)
        {
            npcList.Add(spawnable);
        }

        private void Spawn(IProjectile spawnable)
        {
            npcList.Add(spawnable);
        }
        
        private void Spawn(IBlock spawnable)
        {
            npcList.Add(spawnable);
        }
        
        private void Spawn(IPlayer spawnable)
        {
            npcList.Add(spawnable);
        }
    }
}

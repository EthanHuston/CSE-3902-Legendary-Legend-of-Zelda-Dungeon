using LegendOfZelda.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class SpawnableManager : ISpawnableManager
    {
        public List<IItem> ItemList { get; private set; }
        public List<IProjectile> ProjectileList { get; private set; }
        public List<INpc> NpcList { get; private set; }
        public List<IBlock> BlockList { get; private set; }
        public List<IPlayer> PlayerList { get; private set; }

        public SpawnableManager()
        {
            ItemList = new List<IItem>();
            ProjectileList = new List<IProjectile>();
            NpcList = new List<INpc>();
            BlockList = new List<IBlock>();
            PlayerList = new List<IPlayer>();
        }

        public void Spawn(INpc spawnable)
        {
            NpcList.Add(spawnable);
        }

        public void Spawn(IItem spawnable)
        {
            ItemList.Add(spawnable);
        }

        public void Spawn(IProjectile spawnable)
        {
            ProjectileList.Add(spawnable);
        }

        public void Spawn(IBlock spawnable)
        {
            BlockList.Add(spawnable);
        }

        public void Spawn(IPlayer spawnable)
        {
            PlayerList.Add(spawnable);
        }

        public void DrawAll()
        {
            DrawList(BlockList);
            DrawList(PlayerList);
            DrawList(NpcList);
            DrawList(ItemList);
            DrawList(ProjectileList);
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
            UpdateList(BlockList);
            UpdateList(PlayerList);
            UpdateList(NpcList);
            UpdateList(ItemList);
            UpdateList(ProjectileList);
        }

        private void UpdateList<T>(List<T> list)
        {
            List<int> indicesToRemove = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                ISpawnable item = (ISpawnable)list[i];
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

        public IPlayer GetPlayer(int playerNumber)
        {
            return PlayerList[playerNumber];
        }
    }
}

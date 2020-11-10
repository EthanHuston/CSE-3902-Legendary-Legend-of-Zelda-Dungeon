using LegendOfZelda.Enemies;
using LegendOfZelda.Environment;
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;
using System.CodeDom;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    internal class SpawnableManager : ISpawnableManager
    {
        public List<IItem> ItemList { get; private set; }
        public List<IProjectile> ProjectileList { get; private set; }
        public List<INpc> NpcList { get; private set; }
        public List<IBlock> BlockList { get; private set; }
        public List<IPlayer> PlayerList { get; private set; }
        public List<IBackground> BackgroundList { get; private set; }

        private ItemDrop itemDropper;


        public SpawnableManager(List<IPlayer> playerList)
        {
            ItemList = new List<IItem>();
            ProjectileList = new List<IProjectile>();
            NpcList = new List<INpc>();
            BlockList = new List<IBlock>();
            BackgroundList = new List<IBackground>();
            PlayerList = playerList;
            itemDropper = new ItemDrop(this);
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

        public void Spawn(IBackground spawnable)
        {
            BackgroundList.Add(spawnable);
        }

        public void DrawAll()
        {
            DrawList(BackgroundList);
            DrawList(BlockList);
            DrawList(NpcList);
            DrawList(PlayerList);
            DrawList(ProjectileList);
            DrawList(ItemList);
        }

        private void DrawList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                ISpawnable spawnable = (ISpawnable)list[i];
                spawnable.Draw();
            }
        }

        private void DrawList(List<IItem> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                IItem spawnable = list[i];
                if (typeof(KeyItem) == spawnable.GetType() && NpcList.Count != 0) continue; 
                spawnable.Draw();
            }
        }

        public void UpdateAll()
        {
            UpdateList(BackgroundList);
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
                    if(item.GetType() == typeof(Aquamentus) || item.GetType() == typeof(Skeleton) || item.GetType() == typeof(Goriya) || item.GetType() == typeof(Hand))
                    {
                        itemDropper.DropItem(item.Position);
                    }
                    indicesToRemove.Add(i);
                }
            }

            for (int i = 0; i < indicesToRemove.Count; i++)
            {
                list.RemoveAt(indicesToRemove[i] - i);
            }
        }

        public IPlayer GetPlayer(int playerNumber)
        {
            return PlayerList[playerNumber];
        }

        public void ResetClouds()
        {
            foreach(INpc Npc in NpcList){
                Npc.ResetSpawnCloud();
            }
        }
    }
}

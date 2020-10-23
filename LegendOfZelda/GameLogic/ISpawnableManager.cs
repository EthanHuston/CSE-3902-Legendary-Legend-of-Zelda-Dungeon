using LegendOfZelda.Enemies;
using LegendOfZelda.Environment;
using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.Projectile;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    public interface ISpawnableManager
    {
        List<IItem> ItemList { get; }
        List<IProjectile> ProjectileList { get; }
        List<INpc> NpcList { get; }
        List<IBlock> BlockList { get; }
        List<IPlayer> PlayerList { get; }
        void UpdateAll();
        void DrawAll();
        void Spawn(INpc spawnable);

        void Spawn(IItem spawnable);

        void Spawn(IProjectile spawnable);

        void Spawn(IBlock spawnable);

        void Spawn(IPlayer spawnable);

        IPlayer GetPlayer(int playerNumber);
    }
}

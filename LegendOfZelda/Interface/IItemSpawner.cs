namespace LegendOfZelda.Interface
{
    public interface IItemSpawner
    {
        void UpdateAll();
        void DrawAll();
        void Spawn(INpc spawnable);

        void Spawn(IItem spawnable);

        void Spawn(IProjectile spawnable);

        void Spawn(IBlock spawnable);

        void Spawn(IPlayer spawnable);
    }
}

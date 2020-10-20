namespace LegendOfZelda.Interface
{
    public interface ISpawnableManager
    {
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

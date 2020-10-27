using LegendOfZelda.Link;

namespace LegendOfZelda.GameLogic
{
    public interface IGameState
    {
        ISpawnableManager SpawnableManager { get; }
        void Update();
        void Draw();
        void SwitchToRoomState();
        IPlayer GetPlayer(int playerNumber);
    }
}

using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.GameLogic
{
    internal interface IGameState
    {
        ISpawnableManager SpawnableManager { get; }
        void Update();
        void Draw();
        void SwitchToRoomState();
        IPlayer GetPlayer(int playerNumber);
    }
}

using LegendOfZelda.GameLogic;
using LegendOfZelda.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Rooms
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

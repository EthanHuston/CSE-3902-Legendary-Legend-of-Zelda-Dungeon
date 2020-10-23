using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomGameState : IGameState
    {
        private Game1 game;

        public RoomManager RoomManager { get; private set; }

        public Room CurrentRoom { get => RoomManager.CurrentRoom; }

        public ISpawnableManager SpawnableManager { get => CurrentRoom.AllObjects; }

        public RoomGameState(Game1 game)
        {
            this.game = game;
            RoomFactory roomFactory = new RoomFactory(game);
            RoomManager = new RoomManager(roomFactory.GetStartingRoom());
        }

        public void Update()
        {
            RoomManager.Update();
        }

        public void Draw()
        {
            RoomManager.Draw();
        }

        public void SwitchToRoomState()
        {
            // do nothing, already in room state
        }

        public IPlayer GetPlayer(int playerNumber)
        {
            return CurrentRoom.PlayerList[playerNumber];
        }
    }
}

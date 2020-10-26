using LegendOfZelda.GameLogic;
using LegendOfZelda.Link;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomGameState : IGameState
    {
        private Game1 game;
        public Room CurrentRoom { get; private set; }
        public List<IPlayer> PlayerList { get; private set; } 
        public ISpawnableManager SpawnableManager { get => CurrentRoom.AllObjects; }

        public RoomGameState(Game1 game)
        {
            this.game = game;
            InitPlayersForGame();
            CurrentRoom = RoomFactory.BuildMapAndGetStartRoom(game.SpriteBatch, PlayerList);
        }

        public void Update()
        {
            CurrentRoom.Update();
        }

        public void Draw()
        {
            CurrentRoom.Draw();
        }

        public void SwitchToRoomState()
        {
            // do nothing, already in room state
        }

        public IPlayer GetPlayer(int playerNumber)
        {
            return PlayerList[playerNumber];
        }

        public void MoveRoom(Constants.Direction direction)
        {
            Room newRoom = CurrentRoom.GetRoom(direction);
            CurrentRoom = newRoom ?? CurrentRoom;
        }

        private void InitPlayersForGame()
        {
            PlayerList = new List<IPlayer>()
            {
                {new LinkPlayer(game, Constants.LinkDoorDownSpawnPosition) }
            };
        }
    }
}

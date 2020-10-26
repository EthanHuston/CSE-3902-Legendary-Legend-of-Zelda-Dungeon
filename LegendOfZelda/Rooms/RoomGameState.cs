using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomGameState : IGameState
    {
        private Game1 game;

        public List<IPlayer> PlayerList { get; private set; } 

        public RoomManager RoomManager { get; private set; } // TODO: combine with this

        public Room CurrentRoom { get => RoomManager.CurrentRoom; } // will be combined with this

        public ISpawnableManager SpawnableManager { get => CurrentRoom.AllObjects; }

        public RoomGameState(Game1 game)
        {
            this.game = game;

            InitPlayersForGame();

            RoomFactory roomFactory = new RoomFactory(game.SpriteBatch, PlayerList);
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
            return PlayerList[playerNumber];
        }

        public void MoveRoom(Constants.Direction direction)
        {
            RoomManager.MoveRoom(direction);
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

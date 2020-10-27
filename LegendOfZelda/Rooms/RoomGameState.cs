using LegendOfZelda.GameLogic;
using LegendOfZelda.Link;
using LegendOfZelda.Utility;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    internal class RoomGameState : IGameState
    {
        private readonly Game1 game;
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
            Constants.Direction doorLocation = UtilityMethods.InvertDirection(direction);
            if (newRoom != null)
            {
                CurrentRoom = newRoom;
                UpdatePlayersPositions(doorLocation);
            }
        }

        private void UpdatePlayersPositions(Constants.Direction doorLocation)
        {
            foreach (IPlayer player in PlayerList)
            {
                player.StopMoving();
                switch (doorLocation)
                {
                    case Constants.Direction.Right:
                        player.Position = Constants.LinkDoorRightSpawnPosition;
                        break;
                    case Constants.Direction.Left:
                        player.Position = Constants.LinkDoorLeftSpawnPosition;
                        break;
                    case Constants.Direction.Up:
                        player.Position = Constants.LinkDoorUpSpawnPosition;
                        break;
                    case Constants.Direction.Down:
                        player.Position = Constants.LinkDoorDownSpawnPosition;
                        break;
                }
            }
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

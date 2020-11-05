using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Pause;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class RoomGameState : IGameState
    {
        private List<IController> controllerList;

        public Game1 Game { get; private set; }
        public Room CurrentRoom { get; private set; }
        public List<IPlayer> PlayerList { get; private set; }
        public ISpawnableManager SpawnableManager { get => CurrentRoom.AllObjects; }

        public RoomGameState(Game1 game)
        {
            Game = game;
            InitPlayersForGame();
            InitControllerList();
            CurrentRoom = RoomFactory.BuildMapAndGetStartRoom(game.SpriteBatch, PlayerList);
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this) }
            };
        }

        public void Update()
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            CurrentRoom.Update();
        }

        public void Draw()
        {
            CurrentRoom.Draw();
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
                CurrentRoom.ResetClouds();
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
                        player.Position = LinkConstants.DoorRightSpawnPosition;
                        break;
                    case Constants.Direction.Left:
                        player.Position = LinkConstants.DoorLeftSpawnPosition;
                        break;
                    case Constants.Direction.Up:
                        player.Position = LinkConstants.DoorUpSpawnPosition;
                        break;
                    case Constants.Direction.Down:
                        player.Position = LinkConstants.DoorDownSpawnPosition;
                        break;
                }
            }
        }

        private void InitPlayersForGame()
        {
            PlayerList = new List<IPlayer>()
            {
                {new LinkPlayer(Game, LinkConstants.DoorDownSpawnPosition) }
            };
        }

        public void SwitchToPauseState()
        {
            OldInputState oldInputState = GameStateConstants.GetOldInputState(controllerList);
            Game.SetGameState(new PauseGameState(Game, this), oldInputState);
        }
        public void SwitchToRoomState()
        {
            // do nothing, already in room state
        }

        public void SwitchToMainMenuState()
        {
            // cannot go to main menu from here
        }

        public void SetControllerOldInputState(OldInputState oldInputState)
        {
            foreach (IController controller in controllerList) controller.SetOldInputState(oldInputState);
        }
    }
}

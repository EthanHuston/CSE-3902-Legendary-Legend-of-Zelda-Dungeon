using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.ItemSelectionState;
using LegendOfZelda.GameState.Pause;
using LegendOfZelda.HUDClasses;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class RoomGameState : IGameState
    {
        private List<IController> controllerList;

        public Game1 Game { get; private set; }
        public Room CurrentRoom { get; private set; }
        public List<IPlayer> PlayerList { get; private set; }
        public List<ItemSelectionGameState> itemSelectionGameStates;
        public ISpawnableManager SpawnableManager { get => CurrentRoom.AllObjects; }
        private readonly HUD hud;

        public RoomMap RoomMap { get; private set; }

        public SoundEffectInstance DungeonMusic;

        public RoomGameState(Game1 game)
        {
            Game = game;
            
            InitPlayersForGame();
            
            CurrentRoom = RoomFactory.BuildMapAndGetStartRoom(game.SpriteBatch, PlayerList);
            RoomMap = new RoomMap(game.SpriteBatch, GameStateConstants.MapPieceTextureAtlasSource, GameStateConstants.MapPieceTextureSize, GameStateConstants.MapItemSelectStatePosition + GameStateConstants.MapStartPosition);
            RoomMap.AddRoomToMap(CurrentRoom);
            hud = new HUD(PlayerList);

            InitControllerList();
            InitItemSelectionGameStates();
                        
            DungeonMusic = SoundFactory.Instance.CreateDungeonMusicSound();
            DungeonMusic.IsLooped = true;
            DungeonMusic.Play();
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this) }
            };
        }
        private void InitItemSelectionGameStates()
        {
            itemSelectionGameStates = new List<ItemSelectionGameState>();
            foreach(IPlayer player in PlayerList)
            {
                itemSelectionGameStates.Add(new ItemSelectionGameState(player, this));
            }
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
            hud.Draw(Game.SpriteBatch);
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
                CurrentRoom.Visiting = false;
                newRoom.Visiting = true;

                CurrentRoom = newRoom;
                UpdatePlayersPositions(doorLocation);
                CurrentRoom.ResetClouds();
                RoomMap.AddRoomToMap(CurrentRoom);
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
            Game.SetGameState(new PauseGameState(Game, this), GameStateConstants.GetOldInputState(controllerList));
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

        public void SwitchToItemSelectionState()
        {
            // player 0 inventory for now - in case we add multiplayer later
            Game.SetGameState(itemSelectionGameStates[0], GameStateConstants.GetOldInputState(controllerList));
        }
    }
}

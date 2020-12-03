using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Controller;
using LegendOfZelda.GameState.GameLoseState;
using LegendOfZelda.GameState.GameWinState;
using LegendOfZelda.GameState.ItemSelectionState;
using LegendOfZelda.GameState.PauseState;
using LegendOfZelda.GameState.RoomTransitionState;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.HUDClasses;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.RoomsState
{
    internal class RoomGameState : AbstractGameState
    {
        private readonly SoundEffectInstance dungeonMusic;
        public List<ItemSelectionGameState> itemSelectionGameStates;
        private bool clockModeOn;
        private DateTime clockModeOffTime;

        public IRoom CurrentRoom { get; set; }
        public List<IPlayer> PlayerList { get; private set; }
        public ISpawnableManager SpawnableManager { get => CurrentRoom.AllObjects; }
        public IMenu Hud { get; private set; }
        public RoomMap RoomMap { get; private set; }

        public RoomGameState(Game1 game, int numPlayers)
        {
            Game = game;

            InitPlayersForGame(numPlayers);

            CurrentRoom = RoomFactory.BuildMapAndGetStartRoom(game, PlayerList);
            CurrentRoom.Visiting = true;
            RoomMap = new RoomMap(game.SpriteBatch, ItemSelectionStateConstants.MapPieceTextureAtlasSource, ItemSelectionStateConstants.MapPieceTextureSize, Point.Zero);
            RoomMap.AddRoomToMap(CurrentRoom);
            Hud = new HUD(this);

            InitControllerList(PlayerList);
            InitItemSelectionGameStates();

            UpdatePlayersPositions(Constants.Direction.Down);

            /* 
            dungeonMusic = SoundFactory.Instance.CreateDungeonMusicSound();
            dungeonMusic.IsLooped = true;
            dungeonMusic.Volume = Constants.MusicVolume;
            dungeonMusic.Play();
            */

            dungeonMusic = SoundFactory.Instance.CreateBakaMitaiSound();
            dungeonMusic.IsLooped = true;
            dungeonMusic.Volume = Constants.MusicVolume;
            dungeonMusic.Play();

            clockModeOn = false;
        }

        private void InitControllerList(List<IPlayer> playerList)
        {
            controllerList = new List<IController>();
            foreach (IPlayer player in playerList)
            {
                IGameStateControllerMappings mappings = null;
                switch (player.PlayerNumber)
                {
                    case 0:
                        mappings = new RoomsStateMappingsPlayerOne(this, player);
                        break;
                    case 1:
                        mappings = new RoomsStateMappingsPlayerTwo(this, player);
                        break;
                }

                controllerList.Add(new KeyboardController(mappings.KeyboardMappings, mappings.RepeatableKeyboardKeys));
                controllerList.Add(new MouseController(mappings.MouseMappings, mappings.ButtonMappings, new List<IButton>()));
                controllerList.Add(new GamepadController(mappings.GamepadMappings, mappings.RepeatableGamepadButtons));
            };
        }

        private void InitItemSelectionGameStates()
        {
            itemSelectionGameStates = new List<ItemSelectionGameState>();
            foreach (IPlayer player in PlayerList)
                itemSelectionGameStates.Add(new ItemSelectionGameState(player, this));
        }

        public IPlayer GetPlayer(int playerNumber)
        {
            return PlayerList[playerNumber];
        }

        public void MoveRoom(Constants.Direction direction)
        {
            IRoom newRoom = CurrentRoom.GetRoom(direction);
            if (newRoom != null)
            {
                if (direction != Constants.Direction.Stairs) StartStateSwitch(new RoomTransitionGameState(this, direction));
                else MoveToRoom(newRoom, direction);
                RoomMap.AddRoomToMap(newRoom);
                CurrentRoom.Visiting = false;
                newRoom.Visiting = true;
            }
        }

        public void MoveToRoom(IRoom newRoom, Constants.Direction doorToEnter)
        {
            CurrentRoom.Visiting = false;
            newRoom.Visiting = true;

            CurrentRoom = newRoom;
            UpdatePlayersPositions(doorToEnter);
            CurrentRoom.ResetRoom();
            RoomMap.AddRoomToMap(CurrentRoom);
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

        private void InitPlayersForGame(int numPlayers)
        {
            PlayerList = new List<IPlayer>();
            for (int i = 0; i < numPlayers; i++)
                PlayerList.Add(new LinkPlayer(Game, LinkConstants.DoorDownSpawnPosition, i));
        }

        public override void SwitchToPauseState()
        {
            dungeonMusic.Pause();
            StartStateSwitch(new PauseGameState(Game, this));
        }

        public override void SwitchToItemSelectionState()
        {
            // player 0 inventory for now - in case we add multiplayer later
            StartStateSwitch(itemSelectionGameStates[0]);
        }

        public override void SwitchToDeathState()
        {
            dungeonMusic.Stop();
            StartStateSwitch(new GameLoseGameState(Game, this));
        }

        public override void SwitchToWinState()
        {
            dungeonMusic.Stop();
            StartStateSwitch(new GameWinGameState(Game, this));
        }

        public override void StateEntryProcedure()
        {
            if (dungeonMusic.State != SoundState.Playing) dungeonMusic.Resume();
        }

        public override void StateExitProcedure() { }

        protected override void NormalStateUpdate()
        {
            foreach (IController controller in controllerList) controller.Update();

            if (clockModeOn)
            {
                clockModeOn = DateTime.Compare(DateTime.Now, clockModeOffTime) < 0;
                CurrentRoom.ClockUpdate();
                // For Sprint 5: if(!clockModeOn) SoundFactory.Instance.CreateTimeFlowsSound().Play();
            }
            else CurrentRoom.Update();

            if (PlayerList[0].SafeToDespawn()) SwitchToDeathState();

            Hud.Update();
        }

        protected override void SwitchingStateUpdate()
        {
            readyToSwitchState = true;
        }

        protected override void InitializingStateUpdate()
        {
            stateInitialized = true;
        }

        public override void Draw()
        {
            CurrentRoom.Draw();
            Hud.Draw();
        }

        public void ActivateClockMode()
        {
            clockModeOn = true;
            clockModeOffTime = DateTime.Now + TimeSpan.FromMilliseconds(GameStateConstants.ClockModeLengthMs);
        }
    }
}

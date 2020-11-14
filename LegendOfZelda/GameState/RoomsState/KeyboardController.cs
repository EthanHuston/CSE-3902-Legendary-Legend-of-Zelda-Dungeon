using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> oldKbState;
        private List<Keys> repeatableKeys;
        private List<ICommand> playerStopCommands;

        public KeyboardController(IGameState gameState)
        {
            oldKbState = new List<Keys>();
            InitRepeatableKeys();
            InitControllerMappings(gameState);
        }

        private void InitControllerMappings(IGameState gameState)
        {
            RoomGameState gameStateCast = (RoomGameState)gameState;
            controllerMappings = new Dictionary<Keys, ICommand>
            { 
                { Keys.Escape, new PauseGameCommand(gameState) },
                { Keys.Tab, new ItemSelectCommand(gameState) },

                // Register Player 1 Commands
                { Keys.W, new WalkingForwardCommand(gameStateCast.GetPlayer(0)) },
                { Keys.Up, new WalkingForwardCommand(gameStateCast.GetPlayer(0)) },
                { Keys.A, new WalkingLeftCommand(gameStateCast.GetPlayer(0)) },
                { Keys.Left, new WalkingLeftCommand(gameStateCast.GetPlayer(0)) },
                { Keys.D, new WalkingRightCommand(gameStateCast.GetPlayer(0)) },
                { Keys.Right, new WalkingRightCommand(gameStateCast.GetPlayer(0)) },
                { Keys.S, new WalkingDownCommand(gameStateCast.GetPlayer(0)) },
                { Keys.Down, new WalkingDownCommand(gameStateCast.GetPlayer(0)) },
                { Keys.D1, new UsePrimaryItemCommand(gameStateCast.GetPlayer(0)) },
                { Keys.D2, new UseSecondaryItemCommand(gameStateCast.GetPlayer(0)) },
                { Keys.Q, new UsePrimaryItemCommand(gameStateCast.GetPlayer(0)) },
                { Keys.E, new UseSecondaryItemCommand(gameStateCast.GetPlayer(0)) },

                // TODO: Remove me. Temporary room changing commands
                { Keys.NumPad8, new ChangeRoomUpCommand(gameStateCast) },
                { Keys.NumPad6, new ChangeRoomRightCommand(gameStateCast) },
                { Keys.NumPad2, new ChangeRoomDownCommand(gameStateCast) },
                { Keys.NumPad4, new ChangeRoomLeftCommand(gameStateCast) },
                { Keys.I, new ChangeRoomUpCommand(gameStateCast) },
                { Keys.L, new ChangeRoomRightCommand(gameStateCast) },
                { Keys.K, new ChangeRoomDownCommand(gameStateCast) },
                { Keys.J, new ChangeRoomLeftCommand(gameStateCast) }
            };

            InitPlayerStopMovingCommands(gameStateCast);
        }

        private void InitPlayerStopMovingCommands(RoomGameState gameStateCast)
        {
            for (int i = 0; i < gameStateCast.PlayerList.Count; i++) 
            {
                playerStopCommands.Add(new StopMovingCommand(gameStateCast.PlayerList[i]));
            }
        }

        public GameStateConstants.InputType GetInputType()
        {
            return GameStateConstants.InputType.Keyboard;
        }

        public OldInputState GetOldInputState()
        {
            return new OldInputState { oldKeyboardState = oldKbState };
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void SetOldInputState(OldInputState oldInputState)
        {
            oldKbState = oldInputState.oldKeyboardState;
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            bool changedKbState = false;

            foreach (Keys key in pressedKeys)
            {
                changedKbState = true;
                bool inOldKbState = oldKbState.Contains(key);
                if (inOldKbState) oldKbState.Remove(key);
                if (!repeatableKeys.Contains(key)) oldKbState.Add(key);
                if (controllerMappings.ContainsKey(key) && !inOldKbState)
                {
                    controllerMappings[key].Execute();
                }
            }
            if (!changedKbState) oldKbState = new List<Keys>();
        }

        private void InitRepeatableKeys()
        {
            repeatableKeys = new List<Keys>()
            {
                { Keys.W },
                { Keys.S },
                { Keys.A },
                { Keys.D },
                { Keys.Up },
                { Keys.Left },
                { Keys.Down },
                { Keys.Right }
            };
        }
    }
}

using LegendOfZelda.GameLogic;
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
        private List<PlayerMovementController> playerMovementControllerList;

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

            InitPlayerMovementControllers(gameStateCast);
        }

        private void InitPlayerMovementControllers(RoomGameState gameStateCast)
        {
            playerMovementControllerList = new List<PlayerMovementController>();
            List<IPlayer> playerList = gameStateCast.PlayerList;
            playerMovementControllerList.Add(
                new PlayerMovementController(playerList[0],
                new Dictionary<Constants.Direction, Keys[]>
                    {
                        {Constants.Direction.Right, new Keys[] { Keys.D, Keys.Right } },
                        {Constants.Direction.Up, new Keys[] { Keys.W, Keys.Up } },
                        {Constants.Direction.Left, new Keys[] { Keys.A, Keys.Left } },
                        {Constants.Direction.Down, new Keys[] { Keys.S, Keys.Down } }
                    }
                ));
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
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();
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

            foreach (PlayerMovementController controller in playerMovementControllerList) controller.Update(keyboardState);

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

using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> oldKbState;
        private List<Keys> repeatableKeys;

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
                { Keys.D1, new UsePrimaryItem(gameStateCast.GetPlayer(0)) },
                { Keys.D2, new UseSecondaryItem(gameStateCast.GetPlayer(0)) },
                { Keys.Q, new UsePrimaryItem(gameStateCast.GetPlayer(0)) },
                { Keys.E, new UseSecondaryItem(gameStateCast.GetPlayer(0)) }
            };
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

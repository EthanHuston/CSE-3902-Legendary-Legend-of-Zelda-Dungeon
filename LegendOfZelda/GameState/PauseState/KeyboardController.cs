using LegendOfZelda.GameState.Pause.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Pause
{
    internal class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> oldKbState;
        private List<Keys> repeatableKeys;

        public KeyboardController(IGameState gameState)
        {
            oldKbState = new List<Keys>();
            InitRepeatableKeys();
            controllerMappings = new Dictionary<Keys, ICommand>();

            RegisterCommand(Keys.Escape, new ResumeGameCommand(gameState));
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
                // TODO: Add repeatable keys here
            };
        }
    }
}

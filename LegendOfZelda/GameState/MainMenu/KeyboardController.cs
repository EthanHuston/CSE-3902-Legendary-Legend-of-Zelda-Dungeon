using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenu
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

            // TODO: add commands here
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            List<Keys> newKbState = new List<Keys>();
            foreach (Keys key in pressedKeys)
            {
                bool inOldKbState = oldKbState.Contains(key);
                if (!repeatableKeys.Contains(key)) newKbState.Add(key);
                if (controllerMappings.ContainsKey(key) && !inOldKbState)
                {
                    controllerMappings[key].Execute();
                }
            }
            oldKbState = newKbState;
        }

        private void InitRepeatableKeys()
        {
            repeatableKeys = new List<Keys>()
            {
                // TODO: add repeatable keys here
            };
        }
    }
}

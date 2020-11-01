using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Rooms.Command;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> oldKbState;
        private List<Keys> repeatableKeys;

        public KeyboardController(IGameState gameState)
        {
            RoomGameState gameStateCast = (RoomGameState)gameState;
            oldKbState = new List<Keys>();
            InitRepeatableKeys();
            controllerMappings = new Dictionary<Keys, ICommand>();

            RegisterCommand(Keys.Escape, new PauseGameCommand(gameState));

            // Register Player 1 Commands
            RegisterCommand(Keys.W, new WalkingForwardCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Up, new WalkingForwardCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.A, new WalkingLeftCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Left, new WalkingLeftCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D, new WalkingRightCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Right, new WalkingRightCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.S, new WalkingDownCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Down, new WalkingDownCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Z, new SwordAttackCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.N, new SwordAttackCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.E, new DamageLinkCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D4, new UseBowCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D8, new UseSwordBeamCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D6, new UseBoomerangCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.D7, new UseBombCommand(gameStateCast.GetPlayer(0)));
            RegisterCommand(Keys.Q, new QuitGameCommand(gameState.Game));
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

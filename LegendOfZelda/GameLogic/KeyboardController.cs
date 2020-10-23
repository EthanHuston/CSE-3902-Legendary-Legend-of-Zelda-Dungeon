using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    public class KeyboardController : IController
    {
        private Game1 myGame;
        private Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> oldKbState;
        private List<Keys> repeatableKeys;

        public KeyboardController(Game1 game1)
        {
            myGame = game1;
            oldKbState = new List<Keys>();
            InitRepeatableKeys();
            controllerMappings = new Dictionary<Keys, ICommand>();

            // Register Player 1 Commands
            RegisterCommand(Keys.W, new WalkingForwardCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.Up, new WalkingForwardCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.A, new WalkingLeftCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.Left, new WalkingLeftCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D, new WalkingRightCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.Right, new WalkingRightCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.S, new WalkingDownCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.Down, new WalkingDownCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.Z, new SwordAttackCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.N, new SwordAttackCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.E, new DamageLinkCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D1, new PickUpHeartContainerCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D2, new PickUpTriforcePieceCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D3, new PickUpBowCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D4, new UseBowCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D8, new UseSwordBeamCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D5, new PickUpBoomerangCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D6, new UseBoomerangCommand(game1.GetGamePlayer(1)));
            RegisterCommand(Keys.D7, new UseBombCommand(game1.GetGamePlayer(1)));
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

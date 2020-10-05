﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LegendOfZelda.Link.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class KeyboardController : IController
    {
        private Game1 myGame;
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController(Game1 game1)
        {
            myGame = game1;
            controllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand(Keys.Q, new QuitGameCommand(game1));
            RegisterCommand(Keys.R, new ResetGameCommand(game1));
            RegisterCommand(Keys.W, new WalkingForwardCommand(game1));
            RegisterCommand(Keys.Up, new WalkingForwardCommand(game1));
            RegisterCommand(Keys.A, new WalkingLeftCommand(game1));
            RegisterCommand(Keys.Left, new WalkingLeftCommand(game1));
            RegisterCommand(Keys.D, new WalkingRightCommand(game1));
            RegisterCommand(Keys.Right, new WalkingRightCommand(game1));
            RegisterCommand(Keys.S, new WalkingDownCommand(game1));
            RegisterCommand(Keys.Down, new WalkingDownCommand(game1));
            RegisterCommand(Keys.Z, new SwordAttackCommand(game1));
            RegisterCommand(Keys.N, new SwordAttackCommand(game1));
            RegisterCommand(Keys.E, new DamageLinkCommand(game1));
            RegisterCommand(Keys.D1, new HeartContainerCommand(game1));
            RegisterCommand(Keys.D2, new TriforcePieceCommand(game1));
            RegisterCommand(Keys.D3, new BowCommand(game1));
            RegisterCommand(Keys.D4, new ArrowCommand(game1));
            RegisterCommand(Keys.D5, new WoodenBoomerangHoldCommand(game1));
            RegisterCommand(Keys.D6, new WoodenBoomerangCommand(game1));
            RegisterCommand(Keys.D7, new BombCommand(game1));
            RegisterCommand(Keys.D8, new SwordBeamCommand(game1));
            RegisterCommand(Keys.T, new PreviousBlockCommand(game1));
            RegisterCommand(Keys.Y, new NextBlockCommand(game1));
            RegisterCommand(Keys.U, new PreviousItemCommand(game1));
            RegisterCommand(Keys.I, new NextItemCommand(game1));
            RegisterCommand(Keys.O, new PreviousEnemyCommand(game1));
            RegisterCommand(Keys.P, new NextEnemyCommand(game1));
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
                
            }

        }
    }
}

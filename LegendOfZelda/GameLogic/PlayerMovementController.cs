﻿using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    class PlayerMovementController
    {
        private readonly IPlayer player;
        private Dictionary<Keys, bool> moveKeysPressed;
        private Dictionary<Keys, ICommand> movementControlsDictionary;
        private ICommand stopMovingCommand;
        private Keys previousMovementKey;
        bool keyPressedPreviously;

        public PlayerMovementController(IPlayer player, Dictionary<Constants.Direction, Keys[]> directionToKeys)
        {
            stopMovingCommand = new StopMovingCommand(player);
            this.player = player;
            keyPressedPreviously = false;
            previousMovementKey = Keys.None;
            InitCommandDictionary(directionToKeys);
        }

        private void InitCommandDictionary(Dictionary<Constants.Direction, Keys[]> directionToKeys)
        {
            moveKeysPressed = new Dictionary<Keys, bool>();
            movementControlsDictionary = new Dictionary<Keys, ICommand>();
            foreach (KeyValuePair<Constants.Direction, Keys[]> keyValuePair in directionToKeys)
                RegisterMovementCommand(keyValuePair.Value, GetCommandFromDirection(keyValuePair.Key));
        }

        private void RegisterMovementCommand(Keys[] keys, ICommand command)
        {
            foreach (Keys key in keys)
            {
                moveKeysPressed.Add(key, false);
                movementControlsDictionary.Add(key, command);
            }
        }

        public void Update(KeyboardState keyboardState)
        {
            foreach(KeyValuePair<Keys, ICommand> keyValuePair in movementControlsDictionary)
            {
                Keys key = keyValuePair.Key;
                bool keyPressed = keyboardState.IsKeyDown(key);

                if(keyPressed)
                {
                    movementControlsDictionary[key].Execute();
                    previousMovementKey = key;
                    return;
                }
            }
            stopMovingCommand.Execute();
        }

        private ICommand GetCommandFromDirection(Constants.Direction direction)
        {
            switch (direction)
            {
                case Constants.Direction.Right:
                    return new WalkingRightCommand(player);

                case Constants.Direction.Left:
                    return new WalkingLeftCommand(player);

                case Constants.Direction.Up:
                    return new WalkingForwardCommand(player);

                case Constants.Direction.Down:
                    return new WalkingDownCommand(player);
                default:
                    return null;
            }
        }
    }
}

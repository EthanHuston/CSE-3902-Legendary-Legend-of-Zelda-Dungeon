using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    internal class PlayerMovementController
    {
        private readonly IPlayer player;
        private Dictionary<Keys, ICommand> movementControlsDictionary;
        private readonly ICommand stopMovingCommand;

        public PlayerMovementController(IPlayer player, Dictionary<Constants.Direction, Keys[]> directionToKeys)
        {
            stopMovingCommand = new StopMovingCommand(player);
            this.player = player;
            InitCommandDictionary(directionToKeys);
        }

        private void InitCommandDictionary(Dictionary<Constants.Direction, Keys[]> directionToKeys)
        {
            movementControlsDictionary = new Dictionary<Keys, ICommand>();
            foreach (KeyValuePair<Constants.Direction, Keys[]> keyValuePair in directionToKeys)
                RegisterMovementCommand(keyValuePair.Value, GetCommandFromDirection(keyValuePair.Key));
        }

        private void RegisterMovementCommand(Keys[] keys, ICommand command)
        {
            foreach (Keys key in keys)
            {
                movementControlsDictionary.Add(key, command);
            }
        }

        public void Update(KeyboardState keyboardState)
        {
            foreach (KeyValuePair<Keys, ICommand> keyValuePair in movementControlsDictionary)
            {
                Keys key = keyValuePair.Key;
                bool keyPressed = keyboardState.IsKeyDown(key);

                if (keyPressed)
                {
                    movementControlsDictionary[key].Execute();
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

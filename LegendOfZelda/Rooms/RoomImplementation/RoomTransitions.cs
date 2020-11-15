using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomTransitions : IGameState
    {


        public Game1 Game { get; protected set; }

        private RoomGameState roomGame;

        private IRoom currentRoom;

        private IRoom nextRoom;

        private Constants.Direction direction;

        private Point point;

        private Vector2 velocity;

        private int counter;

        public RoomTransitions(RoomGameState roomGameState, Constants.Direction direction)
        {
            roomGame = roomGameState;
            Game = roomGame.Game;
            this.direction = direction;
            currentRoom = roomGameState.CurrentRoom;
            nextRoom = currentRoom.GetRoom(direction);
            switch (direction)
            {
                case Constants.Direction.Right:
                    point = new Point(RoomConstants.RoomWidth,0);
                    break;
                case Constants.Direction.Left:
                    point = new Point(-1 * RoomConstants.RoomWidth, 0);
                    break;
                case Constants.Direction.Up:
                    point = new Point(0, RoomConstants.RoomHeight);
                    break;
                case Constants.Direction.Down:
                    point = new Point(0, -1 * RoomConstants.RoomHeight);
                    break;
            }
            velocity.X = point.X / 100;
            velocity.Y = point.Y / 100;
            counter = (int) velocity.Length();
            updateObjectPositions();
        }

        private void updateObjectPositions()
        {
            foreach(IBlock block in nextRoom.AllObjects.BlockList)
            {
                block.Position += point;
            }
            foreach (IBackground background in nextRoom.AllObjects.BackgroundList)
            {
                background.Position += point;
            }

        }

        public void Draw()
        {
            foreach (IBlock block in currentRoom.AllObjects.BlockList)
            {
                block.Draw();
            }
            foreach (IBackground background in currentRoom.AllObjects.BackgroundList)
            {
                background.Draw();
            }
            foreach (IBlock block in nextRoom.AllObjects.BlockList)
            {
                block.Draw();
            }
            foreach (IBackground background in nextRoom.AllObjects.BackgroundList)
            {
                background.Draw();
            }
        }

        public void SetControllerOldInputState(OldInputState inputFromOldState)
        {
            //no controller required
        }

        public void StateEntryProcedure()
        {
            //not needed
        }

        public void StateExitProcedure()
        {
            //not needed
        }

        public void SwitchToDeathState()
        {
            //not needed
        }

        public void SwitchToItemSelectionState()
        {
            //not needed
        }

        public void SwitchToMainMenuState()
        {
            //not needed
        }

        public void SwitchToPauseState()
        {
            //not needed
        }

        public void SwitchToRoomState()
        {
            nextRoom.ResetRoom();
            roomGame.StateEntryProcedure();
            Game.State = roomGame;
        }

        public void SwitchToWinState()
        {
            //not needed
        }

        public void Update()
        {
            UpdateBlockPositions();
            counter += (int) velocity.Length();
            if (counter >= point.X  || counter >= point.Y)
            {
                roomGame.CurrentRoom = nextRoom;
                SwitchToRoomState();
            }
        }

        private void UpdateBlockPositions()
        {
            //no controller required
            foreach (IBlock block in currentRoom.AllObjects.BlockList)
            {
                block.Position -= velocity.ToPoint();
            }
            foreach (IBackground background in currentRoom.AllObjects.BackgroundList)
            {
                background.Position -= velocity.ToPoint();
            }
            foreach (IBlock block in nextRoom.AllObjects.BlockList)
            {
                block.Position -= velocity.ToPoint();
            }
            foreach (IBackground background in nextRoom.AllObjects.BackgroundList)
            {
                background.Position -= velocity.ToPoint();
            }
        }
        private void UpdatePlayersPositions(Constants.Direction doorLocation)
        {

            foreach (IPlayer player in roomGame.PlayerList)
            {
                player.StopMoving();
                switch (doorLocation)
                {
                    case Constants.Direction.Right:
                        player.Position = LinkConstants.DoorRightSpawnPosition;
                        break;
                    case Constants.Direction.Left:
                        player.Position = LinkConstants.DoorLeftSpawnPosition;
                        break;
                    case Constants.Direction.Up:
                        player.Position = LinkConstants.DoorUpSpawnPosition;
                        break;
                    case Constants.Direction.Down:
                        player.Position = LinkConstants.DoorDownSpawnPosition;
                        break;
                }
            }
        }
    }
}

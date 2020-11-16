using LegendOfZelda.Environment;
using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameState.RoomTransitionState
{
    class RoomTransitionGameState : IGameState
    {


        public Game1 Game { get; protected set; }

        private readonly RoomGameState roomGameState;

        private readonly IRoom currentRoom;

        private readonly IRoom nextRoom;

        private Vector2 initialMoveDistance;
        private readonly int distanceToMove;
        private const int velocityScalar = 10;
        private Vector2 velocity;
        private Constants.Direction direction;
        private int counter;

        public RoomTransitionGameState(RoomGameState roomGameState, Constants.Direction direction)
        {
            this.roomGameState = roomGameState;
            Game = this.roomGameState.Game;
            this.direction = direction;
            currentRoom = roomGameState.CurrentRoom;
            nextRoom = currentRoom.GetRoom(direction);
            nextRoom.ResetRoom();
            
            initialMoveDistance = GetInitialMoveDistance(direction);
            distanceToMove = (int) initialMoveDistance.Length();

            velocity = GetVelocity(direction);
            counter = 0;
            UpdateObjectPositions(nextRoom, initialMoveDistance);
        }

        private Vector2 GetInitialMoveDistance(Constants.Direction direction)
        {
            Vector2 distance = Vector2.Zero;
            switch (direction)
            {
                case Constants.Direction.Right:
                    distance.X = RoomConstants.RoomWidth;
                    break;
                case Constants.Direction.Left:
                    distance.X = -1 * RoomConstants.RoomWidth;
                    break;
                case Constants.Direction.Up:
                    distance.Y = -1 * RoomConstants.RoomHeight;
                    break;
                case Constants.Direction.Down:
                    distance.Y = RoomConstants.RoomHeight;
                    break;
            }
            return distance;
        }

        private Vector2 GetVelocity(Constants.Direction direction)
        {
            Vector2 velocity = Vector2.Zero;
            switch (direction)
            {
                case Constants.Direction.Right:
                    velocity.X = -1 * velocityScalar;
                    break;
                case Constants.Direction.Left:
                    velocity.X = velocityScalar;
                    break;
                case Constants.Direction.Up:
                    velocity.Y = velocityScalar;
                    break;
                case Constants.Direction.Down:
                    velocity.Y = -1 * velocityScalar;
                    break;
            }
            return velocity;
        }

        private void UpdateObjectPositions(IRoom room, Vector2 distance)
        {
            foreach (IBlock block in room.AllObjects.BlockList)
            {
                block.Position += distance.ToPoint();
            }
            foreach (IBackground background in room.AllObjects.BackgroundList)
            {
                background.Position += distance.ToPoint();
            }
        }

        public void Draw()
        {
            roomGameState.Hud.Draw();
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
            UpdatePlayersPositions(UtilityMethods.InvertDirection(direction));
            UpdateObjectPositions(currentRoom, initialMoveDistance);
            roomGameState.CurrentRoom = nextRoom;
            roomGameState.StateEntryProcedure();
            Game.State = roomGameState;
        }

        public void SwitchToWinState()
        {
            //not needed
        }

        public void Update()
        {
            counter += (int)velocity.Length();
            if (counter >= distanceToMove)
            {
                Vector2 fixVector = new Vector2(velocity.X, velocity.Y);
                fixVector.Normalize();
                fixVector *= distanceToMove - (counter- (int)velocity.Length());
                counter += (int) fixVector.Length();
                UpdateBlockPositions(fixVector);
                SwitchToRoomState();
            } else
            {
                UpdateBlockPositions(velocity);
            }
        }

        private void UpdateBlockPositions(Vector2 distance)
        {
            //no controller required
            foreach (IBlock block in currentRoom.AllObjects.BlockList)
            {
                block.Position += distance.ToPoint();
            }
            foreach (IBackground background in currentRoom.AllObjects.BackgroundList)
            {
                background.Position += distance.ToPoint();
            }
            foreach (IBlock block in nextRoom.AllObjects.BlockList)
            {
                block.Position += distance.ToPoint();
            }
            foreach (IBackground background in nextRoom.AllObjects.BackgroundList)
            {
                background.Position += distance.ToPoint();
            }
        }
        private void UpdatePlayersPositions(Constants.Direction doorLocation)
        {

            foreach (IPlayer player in roomGameState.PlayerList)
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

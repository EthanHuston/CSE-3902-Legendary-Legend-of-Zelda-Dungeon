namespace LegendOfZelda.Rooms
{
    class RoomManager
    {
        private Room currentRoom;

        public RoomManager(Room startingRoom, Game1 game)
        {
            currentRoom = startingRoom;
        }

        public void MoveRoom(Constants.Direction direction)
        {
            currentRoom = currentRoom.GetRoom(direction);
        }

        public void Update()
        {
            currentRoom.Update();
        }

        public void Draw()
        {
            currentRoom.Draw();
        }
    }
}

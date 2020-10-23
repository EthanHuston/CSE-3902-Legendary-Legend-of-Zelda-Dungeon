namespace LegendOfZelda.Rooms
{
    class RoomManager
    {
        public Room CurrentRoom { get; private set; }

        public RoomManager(Room startingRoom)
        {
            CurrentRoom = startingRoom;
        }

        public void MoveRoom(Constants.Direction direction)
        {
            Room newRoom = CurrentRoom.GetRoom(direction);
            CurrentRoom = newRoom == null ? CurrentRoom : newRoom;
        }

        public void Update()
        {
            CurrentRoom.Update();
        }

        public void Draw()
        {
            CurrentRoom.Draw();
        }
    }
}

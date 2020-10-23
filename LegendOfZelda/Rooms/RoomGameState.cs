namespace LegendOfZelda.Rooms
{
    class RoomGameState : IGameState
    {
        private Game1 game;

        public RoomManager RoomManager { get; private set; }

        public Room CurrentRoom { get => RoomManager.CurrentRoom; }

        public RoomGameState(Game1 game)
        {
            this.game = game;
            RoomFactory roomFactory = new RoomFactory(game.SpriteBatch);
            RoomManager = new RoomManager(roomFactory.GetStartingRoom(), game);
        }

        public void Update()
        {
            RoomManager.Update();
        }

        public void Draw()
        {
            RoomManager.Draw();
        }

        public void SwitchToRoomState()
        {
            // do nothing, already in room state
        }
    }
}

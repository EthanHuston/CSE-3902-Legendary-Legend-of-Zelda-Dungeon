namespace LegendOfZelda.Rooms
{
    class RoomGameState : IGameState
    {
        private Game1 game;
        private RoomManager roomManager;

        public RoomGameState(Game1 game)
        {
            this.game = game;
            RoomFactory roomFactory = new RoomFactory(game.SpriteBatch);
            roomManager = new RoomManager(roomFactory.GetStartingRoom(), game);
        }

        public void Update()
        {
            roomManager.Update();
        }

        public void Draw()
        {
            roomManager.Draw();
        }

        public void SwitchToRoomState()
        {
            // do nothing, already in room state
        }
    }
}

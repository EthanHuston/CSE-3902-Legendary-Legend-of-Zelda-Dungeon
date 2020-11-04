namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionGameState : IGameState
    {
        public Game1 Game { get; private set; }

        public ItemSelectionGameState(Game1 game)
        {
            Game = game;
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        public void SetControllerOldInputState(OldInputState oldInputState)
        {
            throw new System.NotImplementedException();
        }

        public void SwitchToMainMenuState()
        {
            throw new System.NotImplementedException();
        }

        public void SwitchToPauseState()
        {
            throw new System.NotImplementedException();
        }

        public void SwitchToRoomState()
        {
            throw new System.NotImplementedException();
        }

        public void SwitchToItemSelectionState()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}

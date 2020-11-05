using System.Collections.Generic;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionGameState : IGameState
    {
        private readonly IGameState roomStatePreserved;
        private List<IController> controllerList;
        private List<ISpawnable> buttonsList;
        private readonly ISpawnable itemSelectionBackground;

        public Game1 Game { get; private set; }

        public ItemSelectionGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = oldRoomState;
            itemSelectionBackground = new ItemSelectionBackground(game.SpriteBatch);
            InitButtonsList();
            InitControllerList();
        }

        private void InitButtonsList()
        {
            buttonsList = new List<ISpawnable>()
            {
            };
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this, buttonsList) }
            };
        }

        public void Draw()
        {
            itemSelectionBackground.Draw();
            foreach (ISpawnable button in buttonsList) button.Draw();
        }

        public void SetControllerOldInputState(OldInputState oldInputState)
        {
            foreach (IController controller in controllerList) controller.SetOldInputState(oldInputState);
        }

        public void SwitchToMainMenuState()
        {
            // do nothing, cannot go to main menu from here
        }

        public void SwitchToPauseState()
        {
            // do nothing, cannot pause from here
        }

        public void SwitchToRoomState()
        {
            Game.SetGameState(roomStatePreserved, GameStateConstants.GetOldInputState(controllerList));
        }

        public void SwitchToItemSelectionState()
        {
            // do nothing, already in item selection state
        }

        public void Update()
        {
            itemSelectionBackground.Update();
        }
    }
}

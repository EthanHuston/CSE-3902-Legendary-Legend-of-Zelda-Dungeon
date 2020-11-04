using System.Collections.Generic;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionGameState : IGameState
    {
        private IGameState roomStatePreserved;
        private List<IController> controllerList;
        private List<ISpawnable> buttons;

        public Game1 Game { get; private set; }

        public ItemSelectionGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = oldRoomState;
            InitButtonsList();
            InitControllerList();
        }

        private void InitButtonsList()
        {
            buttons = new List<ISpawnable>()
            {
            };
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this, buttons) }
            };
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionGameState : IGameState
    {
        private readonly IGameState roomStatePreserved;
        private List<IController> controllerList;
        private readonly IMenu inventoryScreen;

        public Game1 Game { get; private set; }

        public ItemSelectionGameState(IPlayer player, IGameState oldRoomState)
        {
            Game = player.Game;
            roomStatePreserved = oldRoomState;
            inventoryScreen = new InventoryScreen(player);
            InitControllerList(player);
        }

        private void InitControllerList(IPlayer player)
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(player, inventoryScreen.Buttons) }
            };
        }

        public void Draw()
        {
            inventoryScreen.Draw();
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
            foreach (IController controller in controllerList) controller.Update();
            inventoryScreen.Update();
        }
    }
}

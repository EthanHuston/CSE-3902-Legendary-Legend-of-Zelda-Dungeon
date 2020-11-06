﻿using System.Collections.Generic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionGameState : IGameState
    {
        private readonly IGameState roomStatePreserved;
        private List<IController> controllerList;
        private readonly IMenu inventoryMenu;
        private readonly IMenu mapMenu;

        public Game1 Game { get; private set; }

        public ItemSelectionGameState(IPlayer player, RoomGameState oldRoomState)
        {
            Game = player.Game;
            roomStatePreserved = oldRoomState;
            inventoryMenu = new InventoryMenu(player);
            mapMenu = new MapMenu(player, oldRoomState.RoomMap);
            InitControllerList(player);
        }

        private void InitControllerList(IPlayer player)
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(player, inventoryMenu.Buttons) }
            };
        }

        public void Draw()
        {
            inventoryMenu.Draw();
            mapMenu.Draw();
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
            inventoryMenu.Update();
            mapMenu.Update();
        }
    }
}
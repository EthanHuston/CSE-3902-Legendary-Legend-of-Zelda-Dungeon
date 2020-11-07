using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.HUDClasses;
using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionGameState : AbstractGameState
    {
        private readonly IGameState roomStatePreserved;
        private readonly IMenu inventoryMenu;
        private readonly IMenu mapMenu;
        private readonly HUD hud;
        private readonly ICamera camera;

        public ItemSelectionGameState(IPlayer player, RoomGameState oldRoomState)
        {
            Game = player.Game;
            inventoryMenu = new InventoryMenu(player);
            mapMenu = new MapMenu(player, oldRoomState.RoomMap);
            hud = oldRoomState.Hud;
            camera = new Camera(hud, new List<IMenu> { inventoryMenu, mapMenu });
            roomStatePreserved = oldRoomState;
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

        public override void SwitchToRoomState()
        {
            StartStateSwitch(roomStatePreserved);
        }

        public override void StateEntryProcedure()
        {
            camera.Pan(ItemSelectionStateConstants.CameraVelocity, GameStateConstants.ItemSelectStateCameraPanDistance);
        }

        public override void StateExitProcedure()
        {
            camera.ReversePan();
        }

        protected override void NormalStateUpdate()
        {
            foreach (IController controller in controllerList) controller.Update();
            inventoryMenu.Update();
            mapMenu.Update();
            hud.Update();
        }

        protected override void SwitchingStateUpdate()
        {
            camera.Update();
            readyToSwitchState = !camera.IsPanning;
        }

        protected override void InitializingStateUpdate()
        {
            camera.Update();
            stateInitialized = !camera.IsPanning;
        }

        public override void Draw()
        {
            roomStatePreserved.Draw(); // hud gets drawn with room
            inventoryMenu.Draw();
            mapMenu.Draw();
        }
    }
}

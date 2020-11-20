using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class ItemSelectionGameState : AbstractGameState
    {
        private readonly IGameState roomStatePreserved;
        private readonly IMenu mapMenu;
        private readonly IMenu hud;
        private readonly ICamera camera;
        public IButtonMenu InventoryMenu { get; private set; }

        public ItemSelectionGameState(IPlayer player, RoomGameState oldRoomState)
        {
            Game = player.Game;
            InventoryMenu = new InventoryMenu(player);
            mapMenu = new MapMenu(player, oldRoomState.RoomMap);
            hud = oldRoomState.Hud;
            camera = new ItemSelectionStateCamera(hud, new List<IMenu> { InventoryMenu, mapMenu });
            roomStatePreserved = oldRoomState;
            InitControllerList();
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this, InventoryMenu.Buttons) }
            };
        }

        public override void SwitchToRoomState()
        {
            StartStateSwitch(roomStatePreserved);
        }

        public override void StateEntryProcedure()
        {
            InventoryMenu.Update();
            mapMenu.Update();
            camera.Pan(ItemSelectionStateConstants.CameraVelocity, ItemSelectionStateConstants.CameraPanDistance);
        }

        public override void StateExitProcedure()
        {
            camera.ReversePan();
        }

        protected override void NormalStateUpdate()
        {
            foreach (IController controller in controllerList) controller.Update();
            InventoryMenu.Update();
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
            InventoryMenu.Draw();
            mapMenu.Draw();
        }
    }
}

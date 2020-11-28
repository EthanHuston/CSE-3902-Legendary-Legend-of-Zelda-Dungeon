using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.MainMenu;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.PauseState
{
    internal class PauseGameState : AbstractGameState
    {
        private readonly IGameState roomStatePreserved;
        public IButtonMenu PauseGameMenu { get; private set; }

        public PauseGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = oldRoomState;
            PauseGameMenu = new PauseGameMenu(Game);
            InitControllerList();
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this, PauseGameMenu.Buttons) }
            };
        }

        public override void Draw()
        {
            roomStatePreserved.Draw(); // continue to draw the old room in the background
            PauseGameMenu.Draw();
        }

        public override void SwitchToRoomState()
        {
            StartStateSwitch(roomStatePreserved);
        }

        public override void SwitchToMainMenuState()
        {
            StartStateSwitch(new MainMenuGameState(Game));
        }

        public override void StateEntryProcedure()
        {
            // nothing fancy to do here
        }

        public override void StateExitProcedure()
        {
            // nothing fancy to do here
        }

        protected override void NormalStateUpdate()
        {
            foreach (IController controller in controllerList) controller.Update();
            PauseGameMenu.Update();
        }

        protected override void SwitchingStateUpdate()
        {
            readyToSwitchState = true; // nothing fancy to do here
        }

        protected override void InitializingStateUpdate()
        {
            stateInitialized = true; // nothing fancy to do here
        }
    }
}

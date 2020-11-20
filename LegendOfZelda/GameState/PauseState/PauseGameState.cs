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
        private List<IButton> buttons;

        public PauseGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = oldRoomState;
            InitButtonsList();
            InitControllerList();
        }

        private void InitButtonsList()
        {
            buttons = new List<IButton>()
            {
                {new ResumeButton(Game.SpriteBatch, GameStateConstants.PauseStateResumeButtonLocation) },
                {new MainMenuButton(Game.SpriteBatch, GameStateConstants.PauseStateMainMenuButtonLocation) },
                {new ExitButton(Game.SpriteBatch, GameStateConstants.PauseStateExitButtonLocation) }
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

        public override void Draw()
        {
            roomStatePreserved.Draw(); // continue to draw the old room in the background
            foreach (ISpawnable button in buttons) button.Draw();
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

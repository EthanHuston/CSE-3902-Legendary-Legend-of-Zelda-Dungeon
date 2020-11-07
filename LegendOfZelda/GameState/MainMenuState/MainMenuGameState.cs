using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenu
{
    class MainMenuGameState : AbstractGameState
    {
        private readonly ITextureAtlasSprite backgroundSprite;

        public MainMenuGameState(Game1 game)
        {
            Game = game;
            backgroundSprite = GameStateSpriteFactory.Instance.CreateTitleScreenBackgroundSprite();
            InitControllerList();
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this) }
            };
        }

        public override void Draw()
        {
            backgroundSprite.Draw(Game.SpriteBatch, Point.Zero, GameStateConstants.MainMenuTextureMapSource);
        }

        public override void SwitchToRoomState()
        {
            StartStateSwitch(new RoomGameState(Game));
        }

        public override void StateEntryProcedure()
        {
            // shouldn't need to do anything here
        }

        public override void StateExitProcedure()
        {
            // shouldn't need to do anything here
        }

        protected override void NormalStateUpdate()
        {
            foreach (IController controller in controllerList) controller.Update();
        }

        protected override void SwitchingStateUpdate()
        {
            readyToSwitchState = true;
        }

        protected override void InitializingStateUpdate()
        {
            stateInitialized = true;
        }
    }
}

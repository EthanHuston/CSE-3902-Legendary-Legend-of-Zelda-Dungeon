using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenu
{
    class MainMenuGameState : IGameState
    {
        private List<IController> controllerList;
        private readonly ITextureAtlasSprite backgroundSprite;

        public Game1 Game { get; private set; }

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

        public void Draw()
        {
            backgroundSprite.Draw(Game.SpriteBatch, Point.Zero, GameStateConstants.MainMenuTextureMapSource);
        }

        public void SwitchToMainMenuState()
        {
            // Already in main menu state
        }

        public void SwitchToPauseState()
        {
            // cannot switch to pause state from here
        }

        public void SwitchToRoomState()
        {
            Game.SetGameState(new RoomGameState(Game), GameStateConstants.GetOldInputState(controllerList));
        }

        public void Update()
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
        }

        public void SetControllerOldInputState(OldInputState oldInputState)
        {
            foreach (IController controller in controllerList) controller.SetOldInputState(oldInputState);
        }

        public void SwitchToItemSelectionState()
        {
            // do nothing, cannot switch to that state from here
        }
    }
}

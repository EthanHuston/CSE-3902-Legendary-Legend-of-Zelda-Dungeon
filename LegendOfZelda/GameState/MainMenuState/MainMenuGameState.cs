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
        private const int textureMapColumn = 0;
        private const int textureMapRow = 0;

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
            backgroundSprite.Draw(Game.SpriteBatch, Point.Zero, new Point(textureMapColumn, textureMapRow));
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
    }
}

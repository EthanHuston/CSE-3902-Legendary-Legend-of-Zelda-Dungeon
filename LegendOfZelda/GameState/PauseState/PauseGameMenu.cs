using System;
using System.Collections.Generic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameState.PauseState
{
    class PauseGameMenu : IButtonMenu
    {
        private const int numRows = 2, numColumns = 2;

        public ButtonSelector ButtonSelector { get; private set; }
        public List<IButton> Buttons { get; private set; }
        public Point Position { get; set; }

        public PauseGameMenu(Game1 game)
        {
            Buttons = GetButtonsList(game);
            ButtonSelector = new ButtonSelector(game.SpriteBatch, this, Buttons, numColumns);
        }

        private List<IButton> GetButtonsList(Game1 game)
        {
            return new List<IButton>()
            {
                {new ResumeButton(game.SpriteBatch, GameStateConstants.PauseStateResumeButtonLocation) },
                {new MainMenuButton(game.SpriteBatch, GameStateConstants.PauseStateMainMenuButtonLocation) },
                {new ExitButton(game.SpriteBatch, GameStateConstants.PauseStateExitButtonLocation) }
            };
        }

        public void Draw()
        {
            foreach (IButton button in Buttons) button.Draw();
            ButtonSelector.Draw();
        }

        public Rectangle GetRectangle()
        {
            return Rectangle.Empty;
        }

        public void MoveSelection(Constants.Direction direction)
        {
            ButtonSelector.MoveSelector(direction);
        }

        public void Update()
        {
            ButtonSelector.Update();
        }

        public void ToggleButton(Type buttonType)
        {
        }
    }
}

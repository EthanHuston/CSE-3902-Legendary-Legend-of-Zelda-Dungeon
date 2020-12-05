using LegendOfZelda.GameState.Button;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.GameLoseState
{
    internal class GameLoseMenu : IButtonMenu
    {
        private const int numColumns = 1;

        public ButtonSelector ButtonSelector { get; private set; }
        public List<IButton> Buttons { get; private set; }
        public Point Position { get; set; }

        public GameLoseMenu(Game1 game)
        {
            Buttons = GetButtonsList(game);
            ButtonSelector = new ButtonSelector(game.SpriteBatch, this, Buttons, numColumns);
        }

        private List<IButton> GetButtonsList(Game1 game)
        {
            return new List<IButton>()
            {
                {new RetryButtonBlack(game.SpriteBatch, GameStateConstants.LoseStateRetryButtonLocation) },
                {new ExitButtonBlack(game.SpriteBatch, GameStateConstants.LoseStateExitButtonLocation) }
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

using System;
using System.Collections.Generic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameState.OptionState
{
    class OptionMenu : IButtonMenu
    {
        private const int numColumns = 2;

        public ButtonSelector ButtonSelector { get; private set; }
        public List<IButton> Buttons { get; private set; }
        public Point Position { get; set; }

        public OptionMenu(Game1 game)
        {
            Buttons = GetButtonsList(game);
            ButtonSelector = new ButtonSelector(game.SpriteBatch, this, Buttons, numColumns);
        }

        private List<IButton> GetButtonsList(Game1 game)
        {
            return new List<IButton>()
            {
                {new AcceptButton(game.SpriteBatch, GameStateConstants.PauseStateMainMenuButtonLocation) }
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
    }
}

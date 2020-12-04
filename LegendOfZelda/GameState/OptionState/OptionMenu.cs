using LegendOfZelda.GameState.Button;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

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
                {new SinglePlayerButton(game.SpriteBatch, GameStateConstants.OnePlayerButtonLocation)},
                {new TwoPlayerButton(game.SpriteBatch, GameStateConstants.TwoPlayerButtonLocation)},
                {new JojoButton(game.SpriteBatch, GameStateConstants.JojoButtonLocation)},
                {new YakuzaButton(game.SpriteBatch, GameStateConstants.YakuzaButtonLocation)},
                {new PokemonButton(game.SpriteBatch, GameStateConstants.PokemonButtonLocation)},
                {new NormalButton(game.SpriteBatch, GameStateConstants.NormalButtonLocation)},
                {new AcceptButton(game.SpriteBatch, GameStateConstants.AcceptButtonLocation)}
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
            foreach (IOnOffButton button in Buttons)
            {
                if (button.GetType() == buttonType) button.IsOn = !button.IsOn;
            }
        }
    }
}

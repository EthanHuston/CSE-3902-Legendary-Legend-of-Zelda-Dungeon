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
        private Dictionary<Type, IOnOffButton> buttonsDictionary;

        public ButtonSelector ButtonSelector { get; private set; }
        public List<IButton> Buttons { get; private set; }
        public Point Position { get; set; }

        public OptionMenu(Game1 game)
        {
            InitButtonsList(game);
            ButtonSelector = new ButtonSelector(game.SpriteBatch, this, Buttons, numColumns);
        }

        private void InitButtonsList(Game1 game)
        {
            buttonsDictionary = new Dictionary<Type, IOnOffButton>();
            Buttons = new List<IButton>();

            AddToDictionaryAndList(new SinglePlayerButton(game.SpriteBatch, GameStateConstants.OnePlayerButtonLocation));
            AddToDictionaryAndList(new TwoPlayerButton(game.SpriteBatch, GameStateConstants.TwoPlayerButtonLocation));
            AddToDictionaryAndList(new JojoButton(game.SpriteBatch, GameStateConstants.JojoButtonLocation));
            AddToDictionaryAndList(new YakuzaButton(game.SpriteBatch, GameStateConstants.YakuzaButtonLocation));
            AddToDictionaryAndList(new PokemonButton(game.SpriteBatch, GameStateConstants.PokemonButtonLocation));
            AddToDictionaryAndList(new NormalButton(game.SpriteBatch, GameStateConstants.NormalButtonLocation));
            AddToDictionaryAndList(new AcceptButton(game.SpriteBatch, GameStateConstants.AcceptButtonLocation));
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
            buttonsDictionary[buttonType].IsOn = true;
            ToggleOtherButtons(buttonType);
        }

        private void AddToDictionaryAndList(IOnOffButton button)
        {
            buttonsDictionary.Add(button.GetType(), button);
            Buttons.Add(button);
        }

        private void ToggleOtherButtons(Type buttonType)
        {
            if (buttonType == typeof(SinglePlayerButton))
            {
                buttonsDictionary[typeof(TwoPlayerButton)].IsOn = false;
            }
            else if (buttonType == typeof(TwoPlayerButton))
            {
                buttonsDictionary[typeof(SinglePlayerButton)].IsOn = false;
            }
            else if (buttonType == typeof(JojoButton))
            {
                buttonsDictionary[typeof(YakuzaButton)].IsOn = false;
                buttonsDictionary[typeof(NormalButton)].IsOn = false;
                buttonsDictionary[typeof(PokemonButton)].IsOn = false;
            }
            else if (buttonType == typeof(YakuzaButton))
            {
                buttonsDictionary[typeof(JojoButton)].IsOn = false;
                buttonsDictionary[typeof(NormalButton)].IsOn = false;
                buttonsDictionary[typeof(PokemonButton)].IsOn = false;
            }
            else if (buttonType == typeof(PokemonButton))
            {
                buttonsDictionary[typeof(YakuzaButton)].IsOn = false;
                buttonsDictionary[typeof(NormalButton)].IsOn = false;
                buttonsDictionary[typeof(JojoButton)].IsOn = false;
            }
            else if (buttonType == typeof(NormalButton))
            {
                buttonsDictionary[typeof(YakuzaButton)].IsOn = false;
                buttonsDictionary[typeof(PokemonButton)].IsOn = false;
                buttonsDictionary[typeof(JojoButton)].IsOn = false;
            }
        }
    }
}

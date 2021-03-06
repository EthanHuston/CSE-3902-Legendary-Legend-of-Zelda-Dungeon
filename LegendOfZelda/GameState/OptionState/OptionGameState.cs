﻿using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Controller;
using LegendOfZelda.GameState.MainMenuState;
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.OptionState
{
    internal class OptionGameState : IGameState
    {
        private readonly List<IController> controllerList;
        private readonly SoundEffectInstance titleScreenMusic;

        public Game1 Game { get; private set; }
        public IButtonMenu OptionMenu { get; private set; }

        public OptionGameState(Game1 game, SoundEffectInstance titleScreenMusic)
        {
            Game = game;
            OptionMenu = new OptionMenu(Game);
            controllerList = GetControllerList();
            this.titleScreenMusic = titleScreenMusic;
        }

        private List<IController> GetControllerList()
        {
            IGameStateControllerMappings mappings = new OptionMapping(this);
            return new List<IController>()
            {
                {new KeyboardController(mappings.KeyboardMappings, mappings.RepeatableKeyboardKeys) },
                {new MouseController(mappings.MouseMappings, mappings.ButtonMappings, OptionMenu.Buttons) },
                {new GamepadController(mappings.GamepadMappings, mappings.RepeatableGamepadButtons) }
            };
        }

        public void Draw()
        {
            OptionMenu.Draw();
        }

        public void SwitchToRoomState()
        {
            StateExitProcedure();

            SpriteFactory.Instance.LoadAllTextures(Game.Content);
            SoundFactory.Instance.LoadAllSounds(Game.Content);

            foreach (IOnOffButton button in OptionMenu.Buttons)
                if (button.IsOn) UpdateGameFromButtonStatus(button.GetType());

            Game.State = new RoomGameState(Game);
            Game.State.SetControllerOldInputState(GameStateMethods.GetOldInputState(controllerList));
            Game.State.StateEntryProcedure();
        }

        public void SwitchToMainMenuState()
        {
            StateExitProcedure();
            Game.State = new MainMenuGameState(Game);
            Game.State.SetControllerOldInputState(GameStateMethods.GetOldInputState(controllerList));
            Game.State.StateEntryProcedure();
        }

        public void StateEntryProcedure() { }

        public void StateExitProcedure()
        {
            titleScreenMusic.Stop();
        }

        public void Update()
        {
            foreach (IController controller in controllerList) controller.Update();
            OptionMenu.Update();
        }

        public void SwitchToPauseState() { }

        public void SwitchToItemSelectionState() { }

        public void SwitchToDeathState() { }

        public void SwitchToWinState() { }

        public void SetControllerOldInputState(InputStates inputFromOldState)
        {
            foreach (IController controller in controllerList) controller.OldInputState = inputFromOldState;
        }

        private void UpdateGameFromButtonStatus(Type buttonType)
        {
            if (buttonType == typeof(SinglePlayerButton))
            {
                Game.NumPlayers = 1;
            }
            else if (buttonType == typeof(TwoPlayerButton))
            {
                Game.NumPlayers = 2;
            }
            else if (buttonType == typeof(JojoButton))
            {
                SoundFactory.Instance.LoadJojoSounds();
            }
            else if (buttonType == typeof(YakuzaButton))
            {
                SoundFactory.Instance.LoadYakuzaSounds();
            }
            else if (buttonType == typeof(PokemonButton))
            {
                SpriteFactory.Instance.LoadPokemonTextures();
            }
            else if (buttonType == typeof(NormalButton))
            {
            }
        }

        public void SwitchToOptionState() { }

        public void SwitchToItemSelectionState(int playerNum) { }
    }
}

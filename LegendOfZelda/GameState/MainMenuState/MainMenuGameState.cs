using LegendOfZelda.GameState.Controller;
using LegendOfZelda.GameState.OptionState;
using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenuState
{
    internal class MainMenuGameState : AbstractGameState
    {
        private readonly ISprite backgroundSprite;
        private SoundEffectInstance titleSound;

        public MainMenuGameState(Game1 game)
        {
            Game = game;
            backgroundSprite = GameStateSpriteFactory.Instance.CreateTitleScreenBackgroundSprite();
            InitControllerList();
        }

        private void InitControllerList()
        {
            IGameStateControllerMappings mappings = new MainMenuStateMappings(this);
            controllerList = new List<IController>()
            {
                {new KeyboardController(mappings.KeyboardMappings, mappings.RepeatableKeyboardKeys) },
                {new MouseController(mappings.MouseMappings, mappings.ButtonMappings, new List<IButton>()) },
                {new GamepadController(mappings.GamepadMappings, mappings.RepeatableGamepadButtons) }
            };
        }

        public override void Draw()
        {
            backgroundSprite.Draw(Game.SpriteBatch, Point.Zero, Constants.DrawLayer.Menu);
        }

        public override void SwitchToRoomState() { }

        public override void StateEntryProcedure()
        {
            titleSound = SoundFactory.Instance.CreateTitleSound();
            titleSound.IsLooped = true;
            titleSound.Volume = Constants.MusicVolume;
            titleSound.Play();
        }

        public override void StateExitProcedure()
        {
            titleSound.Stop();
        }

        protected override void NormalStateUpdate()
        {
            foreach (IController controller in controllerList) controller.Update();
            backgroundSprite.Update();
        }

        protected override void SwitchingStateUpdate()
        {
            readyToSwitchState = true;
        }

        protected override void InitializingStateUpdate()
        {
            stateInitialized = true;
        }

        public override void SwitchToOptionState()
        {
            StartStateSwitch(new OptionGameState(Game));
        }
    }
}

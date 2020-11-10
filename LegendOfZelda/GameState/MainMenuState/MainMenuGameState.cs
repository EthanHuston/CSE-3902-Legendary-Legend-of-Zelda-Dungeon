using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenu
{
    class MainMenuGameState : AbstractGameState
    {
        private readonly ITextureAtlasSprite backgroundSprite;
        private SoundEffectInstance titleSound;

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
            backgroundSprite.Draw(Game.SpriteBatch, Point.Zero, GameStateConstants.MainMenuTextureMapSource, Constants.DrawLayer.Menu);
        }

        public override void SwitchToRoomState()
        {
            StartStateSwitch(new RoomGameState(Game));
        }

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

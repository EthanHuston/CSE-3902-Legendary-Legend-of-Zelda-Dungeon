using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.MainMenu;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.GameLoseState
{
    class GameWinState : AbstractGameState
    {
        private readonly RoomGameState roomStatePreserved;
        private List<ISpawnable> buttons;
        private SpawnableManager spawnableManager;
        private ISprite winSprite;
        private ISprite blackOverlaySprite;
        private SoundEffectInstance win;
        private bool phaseOne = true;
        private bool phaseTwo = false;
        private int phaseOneBuffer = 0;

        public GameWinState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = (RoomGameState)oldRoomState;
            spawnableManager = (SpawnableManager)roomStatePreserved.SpawnableManager;
            win = SoundFactory.Instance.CreateWinSound();
            winSprite = GameStateSpriteFactory.Instance.CreateGameOverSprite();
            blackOverlaySprite = GameStateSpriteFactory.Instance.CreateRedOverlaySprite();
        }

        public override void Draw()
        {
            if (phaseOne)
            {
                // Music play
                // Screen flashes white twice?
                // Heart refill
            }
            else if (phaseTwo)
            {
                // Black Screen closes in
                // Game quits
            }
        }

        public override void SwitchToRoomState()
        {
            StartStateSwitch(roomStatePreserved);
        }

        public override void SwitchToMainMenuState()
        {
            StartStateSwitch(new MainMenuGameState(Game));
        }

        public override void StateEntryProcedure()
        {
            // nothing fancy to do here
        }

        public override void StateExitProcedure()
        {
            // nothing fancy to do here
        }

        protected override void NormalStateUpdate()
        {
            foreach (IController controller in controllerList) controller.Update();
        }

        protected override void SwitchingStateUpdate()
        {
            readyToSwitchState = true; // nothing fancy to do here
        }

        protected override void InitializingStateUpdate()
        {
            stateInitialized = true; // nothing fancy to do here
        }
    }
}


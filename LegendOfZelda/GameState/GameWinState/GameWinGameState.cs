using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.MainMenu;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.GameWinState
{
    class GameWinGameState : AbstractGameState
    {
        private readonly RoomGameState roomStatePreserved;
        private List<ISpawnable> buttons;
        private SpawnableManager spawnableManager;
        private SoundEffectInstance win;
        private SoundEffectInstance refill;
        private bool phaseOne = true;
        private bool phaseTwo = false;
        private bool phaseThree = false;
        private int phaseOneBuffer = 0;
        private int phaseTwoBuffer = 0;

        public GameWinGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = (RoomGameState)oldRoomState;
            spawnableManager = (SpawnableManager)roomStatePreserved.SpawnableManager;
            win = SoundFactory.Instance.CreateWinSound();
            refill = SoundFactory.Instance.CreateRefillSound();
        }

        public override void Draw()
        {
            spawnableManager.DrawGameWin();
            roomStatePreserved.Hud.Draw();
            if (phaseThree)
            {
                blackOverlaySpriteLeft.Draw(Game.SpriteBatch, GameStateConstants.WinStateSpriteLocationLeft, Constants.DrawLayer.BlackLayer);
                blackOverlaySpriteRight.Draw(Game.SpriteBatch, GameStateConstants.WinStateSpriteLocationRight, Constants.DrawLayer.BlackLayer);
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
            win.Play();
        }

        public override void StateExitProcedure()
        {
            // nothing fancy to do here
        }

        public override void SetControllerOldInputState(OldInputState inputFromOldState)
        {
            // This does nothing.
        }

        protected override void NormalStateUpdate()
        {
            roomStatePreserved.Hud.Update();
            spawnableManager.PlayerList[0].Update();
            if (phaseOne)
            {
                phaseOneBuffer++;
                if (phaseOneBuffer == 150)
                {
                    phaseOne = false;
                    phaseTwo = true;
                }
                
            }
            else if (phaseTwo)
            {
                phaseTwoBuffer++;
                if (phaseTwoBuffer == 5)
                {
                    spawnableManager.PlayerList[0].BeHealthy(Constants.HeartValue / 2);
                    refill.Play();
                    phaseTwoBuffer = 0;
                }

                if (spawnableManager.PlayerList[0].CurrentHealth == spawnableManager.PlayerList[0].MaxHealth)
                {
                    phaseTwo = false;
                    phaseThree = true;
                }
            }
            else if (phaseThree)
            {
                blackOverlaySpriteLeft.Update();
                blackOverlaySpriteRight.Update();
            }
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


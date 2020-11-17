using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.MainMenu;
using LegendOfZelda.GameState.Rooms;
using Microsoft.Xna.Framework.Audio;

namespace LegendOfZelda.GameState.GameWinState
{
    internal class GameWinGameState : AbstractGameState
    {
        private readonly RoomGameState roomStatePreserved;
        private readonly SpawnableManager spawnableManager;
        private readonly SoundEffectInstance win;
        private readonly SoundEffectInstance refill;
        private readonly Curtain curtain;
        private bool phaseOne = true;
        private bool phaseTwo = false;
        private bool phaseThree = false;
        private bool phaseFour = false;
        private int phaseOneBuffer = 0;
        private int phaseTwoBuffer = 0;
        private int cBuffer = 0;

        public GameWinGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = (RoomGameState)oldRoomState;
            spawnableManager = (SpawnableManager)roomStatePreserved.SpawnableManager;
            curtain = new Curtain(game.SpriteBatch);
            win = SoundFactory.Instance.CreateWinSound();
            refill = SoundFactory.Instance.CreateRefillSound();
        }

        public override void Draw()
        {
            spawnableManager.DrawGameWin();
            roomStatePreserved.Hud.Draw();
            if (phaseThree)
            {
                curtain.Draw();
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
                curtain.Update();
                cBuffer++;
                if (cBuffer == 450)
                {
                    phaseThree = false;
                    phaseFour = true;
                }
            }
            else if (phaseFour)
            {
                Game.Exit();
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


using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.GameState.Utilities;
using Microsoft.Xna.Framework.Audio;

namespace LegendOfZelda.GameState.GameWinState
{
    internal class GameWinGameState : IGameState
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

        public Game1 Game { get; private set; }

        public GameWinGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = (RoomGameState)oldRoomState;
            spawnableManager = (SpawnableManager)roomStatePreserved.SpawnableManager;
            curtain = new Curtain(game.SpriteBatch);
            win = SoundFactory.Instance.CreateWinSound();
            refill = SoundFactory.Instance.CreateRefillSound();
        }

        public void SetControllerOldInputState(InputStates inputFromOldState) { }

        public void StateEntryProcedure() { win.Play(); }

        public void StateExitProcedure() { }

        public void Update()
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

        public void Draw()
        {
            spawnableManager.DrawGameWin();
            roomStatePreserved.Hud.Draw();
            if (phaseThree)
            {
                curtain.Draw();
            }
        }

        public void SwitchToPauseState() { }

        public void SwitchToItemSelectionState() { }

        public void SwitchToDeathState() { }

        public void SwitchToWinState() { }

        public void SwitchToRoomState() { }

        public void SwitchToMainMenuState() { }
    }
}


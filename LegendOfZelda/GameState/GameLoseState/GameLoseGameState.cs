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
    internal class GameLoseGameState : AbstractGameState
    {
        private readonly RoomGameState roomStatePreserved;
        private List<ISpawnable> buttons;
        private readonly SpawnableManager spawnableManager;
        private readonly ISprite gameOverSprite;
        private readonly ISprite redOverlaySprite;
        private readonly SoundEffectInstance game_over;
        private readonly SoundEffectInstance link_die;
        private bool phaseOne = true;
        private bool phaseTwo = false;
        private bool phaseThree = false;
        private int phaseOneBuffer = 0;
        private int phaseTwoBuffer = 0;

        public GameLoseGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = (RoomGameState)oldRoomState;
            spawnableManager = (SpawnableManager)roomStatePreserved.SpawnableManager;
            link_die = SoundFactory.Instance.CreateLinkDieSound();
            game_over = SoundFactory.Instance.CreateGameOverSound();
            gameOverSprite = GameStateSpriteFactory.Instance.CreateGameOverSprite();
            redOverlaySprite = GameStateSpriteFactory.Instance.CreateRedOverlaySprite();
            InitButtonsList();
            InitControllerList();
        }

        private void InitButtonsList()
        {
            buttons = new List<ISpawnable>()
            {
                {new RetryButtonBlack(Game.SpriteBatch, GameStateConstants.LoseStateRetryButtonLocation) },
                {new ExitButtonBlack(Game.SpriteBatch, GameStateConstants.LoseStateExitButtonLocation) }
            };
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this, buttons) }
            };
        }

        public override void Draw()
        {
            if (phaseOne)
            {
                spawnableManager.DrawGameLose();
                roomStatePreserved.Hud.Draw();
                redOverlaySprite.Draw(Game.SpriteBatch, new Point(Constants.MinXPos, Constants.MinYPos), Constants.DrawLayer.RedDeathBlanket);
                link_die.Play();
            }
            else if (phaseTwo)
            {
                gameOverSprite.Draw(Game.SpriteBatch, GameStateConstants.LoseStateGameOverSpriteLocation, Constants.DrawLayer.MenuButton);
                game_over.IsLooped = true;
                game_over.Play();
            }
            else if (phaseThree)
            {
                foreach (ISpawnable button in buttons) button.Draw();
            }
        }

        public override void SwitchToRoomState()
        {
            StartStateSwitch(roomStatePreserved);
        }

        public override void SwitchToMainMenuState()
        {
            game_over.Stop();
            StartStateSwitch(new MainMenuGameState(Game));
        }

        public override void StateEntryProcedure()
        {
            roomStatePreserved.GetPlayer(0).StartDeathAnimation();
        }

        public override void StateExitProcedure()
        {
            // nothing fancy to do here
        }

        protected override void NormalStateUpdate()
        {
            if (phaseOne)
            {
                phaseOneBuffer++;
                spawnableManager.PlayerList[0].Update();
                if (phaseOneBuffer == 150)
                {
                    phaseOne = false;
                    phaseTwo = true;
                }
            }
            else if (phaseTwo)
            {
                phaseTwoBuffer++;
                if (phaseTwoBuffer > 150)
                {
                    phaseTwo = false;
                    phaseThree = true;
                }

            }
            else if (phaseThree)
            {
                foreach (IController controller in controllerList) controller.Update();
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


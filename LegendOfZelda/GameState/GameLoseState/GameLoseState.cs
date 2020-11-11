using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.MainMenu;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.GameLoseState
{
    class GameLoseState : AbstractGameState
    {
        private readonly RoomGameState roomStatePreserved;
        private List<ISpawnable> buttons;
        private SpawnableManager spawnableManager;
        private ISprite gameOverSprite;
        private bool phaseOneDone = false;
        private bool phaseTwoDone = false;
        private int phaseTwoBuffer = 0;

        public GameLoseState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = (RoomGameState)oldRoomState;
            spawnableManager = (SpawnableManager)roomStatePreserved.SpawnableManager;
            gameOverSprite = GameStateSpriteFactory.Instance.CreateGameOverSprite();
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
            if (phaseOneDone)
            {
                gameOverSprite.Draw(Game.SpriteBatch, GameStateConstants.LoseStateGameOverSpriteLocation);
            } else if (phaseTwoDone)
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
            StartStateSwitch(new MainMenuGameState(Game));
        }

        public override void StateEntryProcedure()
        {
            // Despawn enemies, draw environment red, start link spinning
            spawnableManager.DrawGameLose();
            roomStatePreserved.GetPlayer(0);
            phaseOneDone = true;
        }

        public override void StateExitProcedure()
        {
            // nothing fancy to do here
        }

        protected override void NormalStateUpdate()
        {
            if (phaseOneDone)
            {
                phaseTwoBuffer++;
                if(phaseTwoBuffer > 30)
                {
                    phaseTwoDone = true;
                }

            }
            else if(phaseTwoDone)
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


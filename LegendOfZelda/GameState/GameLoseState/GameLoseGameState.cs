using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Controller;
using LegendOfZelda.GameState.MainMenuState;
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.GameLoseState
{
    internal class GameLoseGameState : IGameState
    {
        private readonly List<IController> controllerList;
        private readonly RoomGameState roomStatePreserved;
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
        public IButtonMenu GameLoseMenu { get; private set; }

        public GameLoseGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = (RoomGameState)oldRoomState;
            spawnableManager = (SpawnableManager)roomStatePreserved.SpawnableManager;
            link_die = SoundFactory.Instance.CreateLinkDieSound();
            game_over = SoundFactory.Instance.CreateGameOverSound();
            gameOverSprite = GameStateSpriteFactory.Instance.CreateGameOverSprite();
            redOverlaySprite = GameStateSpriteFactory.Instance.CreateRedOverlaySprite();

            GameLoseMenu = new GameLoseMenu(Game);

            controllerList = GetControllerList(GameLoseMenu.Buttons);
        }

        public Game1 Game { get; protected set; }

        private List<IController> GetControllerList(List<IButton> buttons)
        {
            IGameStateControllerMappings mappings = new GameLoseStateMappings(this);
            return new List<IController>()
            {
                {new KeyboardController(mappings.KeyboardMappings, mappings.RepeatableKeyboardKeys) },
                {new MouseController(mappings.MouseMappings, mappings.ButtonMappings, buttons) },
                {new GamepadController(mappings.GamepadMappings, mappings.RepeatableGamepadButtons) }
            };
        }

        public void Draw()
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
                GameLoseMenu.Draw();
            }
        }

        public void SwitchToRoomState() { }

        public void SwitchToMainMenuState()
        {
            game_over.Stop();
            StateExitProcedure();
            Game.State = new MainMenuGameState(Game);
            Game.State.SetControllerOldInputState(GameStateMethods.GetOldInputState(controllerList));
            Game.State.StateEntryProcedure();
        }

        public void StateEntryProcedure()
        {
        }

        public void StateExitProcedure() { }

        public void Update()
        {
            if (phaseOne)
            {
                phaseOneBuffer++;
                for (int i = 0; i < spawnableManager.PlayerList.Count; i++)
                    if (!spawnableManager.PlayerList[i].SafeToDespawn) spawnableManager.PlayerList[i].Update();

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
                GameLoseMenu.Update();
            }
        }

        public void SetControllerOldInputState(InputStates inputFromOldState)
        {
            foreach (IController controller in controllerList) controller.OldInputState = inputFromOldState;
        }

        public void SwitchToPauseState() { }

        public void SwitchToItemSelectionState(int playerNum) { }

        public void SwitchToDeathState() { }

        public void SwitchToWinState() { }

        public void SwitchToOptionState() { }
    }
}


using LegendOfZelda.GameState.Utilities;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    internal abstract class AbstractGameState : IGameState
    {
        protected List<IController> controllerList;
        protected bool changingStates;
        protected bool stateInitialized;
        protected bool readyToSwitchState;
        private IGameState pendingGameState;

        public Game1 Game { get; protected set; }

        protected AbstractGameState()
        {
            readyToSwitchState = false;
            changingStates = false;
            stateInitialized = false;
        }

        public virtual void Update()
        {
            if (changingStates)
            {
                SwitchingStateUpdate();
                if (readyToSwitchState) FinishStateSwitch();
            }
            else if (!stateInitialized)
            {
                InitializingStateUpdate();
            }
            else
            {
                NormalStateUpdate();
            }
        }

        public virtual void SetControllerOldInputState(InputStates inputFromOldState)
        {
            foreach (IController controller in controllerList) controller.OldInputState = inputFromOldState;
        }

        protected void StartStateSwitch(IGameState gameState)
        {
            readyToSwitchState = false;
            changingStates = true;
            pendingGameState = gameState;
            StateExitProcedure();
        }

        protected void FinishStateSwitch()
        {
            readyToSwitchState = false;
            changingStates = false;
            stateInitialized = false;
            pendingGameState.SetControllerOldInputState(GameStateMethods.GetOldInputState(controllerList));
            Game.State = pendingGameState;
            Game.State.StateEntryProcedure();
        }

        public virtual void SwitchToItemSelectionState() { }
        public virtual void SwitchToMainMenuState() { }
        public virtual void SwitchToPauseState() { }
        public virtual void SwitchToRoomState() { }
        public virtual void SwitchToDeathState() { }
        public virtual void SwitchToWinState() { }
        public abstract void StateEntryProcedure();
        public abstract void StateExitProcedure();
        protected abstract void NormalStateUpdate();
        protected abstract void SwitchingStateUpdate();
        protected abstract void InitializingStateUpdate();
        public abstract void Draw();
    }
}

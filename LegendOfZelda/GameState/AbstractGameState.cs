using System.Collections.Generic;
using static LegendOfZelda.GameState.GameStateConstants;

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

        public void SetControllerOldInputState(OldInputState inputFromOldState)
        {
            foreach (IController controller in controllerList) controller.SetOldInputState(inputFromOldState);
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
            pendingGameState.SetControllerOldInputState(GetOldInputState());
            Game.State = pendingGameState;
            Game.State.StateEntryProcedure();
        }

        public virtual void SwitchToItemSelectionState() { }
        public virtual void SwitchToMainMenuState() { }
        public virtual void SwitchToPauseState() { }
        public virtual void SwitchToRoomState() { }
        public abstract void StateEntryProcedure();
        public abstract void StateExitProcedure();
        protected abstract void NormalStateUpdate();
        protected abstract void SwitchingStateUpdate();
        protected abstract void InitializingStateUpdate();
        public abstract void Draw();

        private OldInputState GetOldInputState()
        {
            OldInputState oldInputState = new OldInputState();

            foreach (IController controller in controllerList)
            {
                switch (controller.GetInputType())
                {
                    case InputType.Keyboard:
                        oldInputState.oldKeyboardState = controller.GetOldInputState().oldKeyboardState;
                        break;

                    case InputType.Mouse:
                        oldInputState.oldMouseState = controller.GetOldInputState().oldMouseState;
                        break;
                }
            }

            return oldInputState;
        }
    }
}

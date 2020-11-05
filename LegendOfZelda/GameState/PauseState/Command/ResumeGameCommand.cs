﻿using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Pause.Command
{
    class ResumeGameCommand : ICommand
    {
        private IGameState gameState;

        public ResumeGameCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.SwitchToRoomState();
        }
    }
}
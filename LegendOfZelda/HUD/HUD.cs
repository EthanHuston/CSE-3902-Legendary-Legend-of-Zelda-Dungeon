using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Pause;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using System.Collections.Generic;

namespace LegendOfZelda.HUD
{
    internal class HUD
    {
        List<IPlayer> players;

        public HUD(List<IPlayer> players)
        {
            this.players = players;
        }
    }
}

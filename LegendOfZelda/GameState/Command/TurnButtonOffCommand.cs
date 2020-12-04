using LegendOfZelda.Interface;
using LegendOfZelda.Menu;

namespace LegendOfZelda.GameState.Command
{
    class TurnButtonOffCommand : ICommand
    {
        private readonly IOnOffButton button;

        public TurnButtonOffCommand(IOnOffButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.IsOn = false;
        }
    }
}

using LegendOfZelda.Interface;
using LegendOfZelda.Menu;

namespace LegendOfZelda.GameState.Command
{
    class TurnButtonOnCommand : ICommand
    {
        private readonly IOnOffButton button;

        public TurnButtonOnCommand(IOnOffButton button)
        {
            this.button = button;
        }

        public void Execute()
        {
            button.IsOn = true;
        }
    }
}

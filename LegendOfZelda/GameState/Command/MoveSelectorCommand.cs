using LegendOfZelda.Interface;
using LegendOfZelda.Menu;

namespace LegendOfZelda.GameState.Command
{
    internal class MoveSelectorCommand : ICommand
    {
        private readonly IButtonMenu menu;
        private readonly Constants.Direction direction;

        public MoveSelectorCommand(IButtonMenu menu, Constants.Direction direction)
        {
            this.menu = menu;
            this.direction = direction;
        }

        public void Execute()
        {
            menu.MoveSelection(direction);
        }
    }
}

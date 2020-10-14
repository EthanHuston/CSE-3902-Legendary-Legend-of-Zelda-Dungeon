using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class PickUpBowCommand : ICommand
    {
        private Game1 loz;
        public PickUpBowCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpBow();
        }
    }
}

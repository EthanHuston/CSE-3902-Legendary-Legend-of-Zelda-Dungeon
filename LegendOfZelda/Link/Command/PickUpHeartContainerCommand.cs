using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class PickUpHeartContainerCommand : ICommand
    {
        private Game1 loz;
        public PickUpHeartContainerCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpHeartContainer();
        }
    }
}

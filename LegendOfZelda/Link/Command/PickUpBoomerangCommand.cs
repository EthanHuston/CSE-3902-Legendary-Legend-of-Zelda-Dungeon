
using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class PickUpBoomerangCommand : ICommand
    {
        private Game1 loz;
        public PickUpBoomerangCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpBoomerang();
        }
    }
}

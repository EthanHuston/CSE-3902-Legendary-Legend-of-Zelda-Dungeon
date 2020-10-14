using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class UseBoomerangCommand : ICommand
    {
        private Game1 loz;
        public UseBoomerangCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseBoomerang();
        }
    }
}

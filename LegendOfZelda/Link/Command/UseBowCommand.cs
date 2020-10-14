using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class UseBowCommand : ICommand
    {
        private Game1 loz;
        public UseBowCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseBow();
        }
    }
}

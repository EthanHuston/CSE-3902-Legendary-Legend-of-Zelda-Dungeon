using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class WalkingRightCommand : ICommand
    {
        private Game1 loz;
        public WalkingRightCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.MoveRight();
        }
    }
}

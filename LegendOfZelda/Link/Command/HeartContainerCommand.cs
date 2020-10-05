namespace LegendOfZelda.Link.Command
{
    class HeartContainerCommand : ICommand
    {
        private Game1 loz;
        public HeartContainerCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpHeartContainer();
        }
    }
}

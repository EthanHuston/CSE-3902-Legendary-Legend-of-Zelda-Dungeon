namespace Sprint0.Link.Command
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

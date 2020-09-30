﻿namespace Sprint0.Link.Command
{
    class WalkingLeftCommand : ICommand
    {
        private Game1 loz;
        public WalkingLeftCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.MoveLeft();
        }
    }
}
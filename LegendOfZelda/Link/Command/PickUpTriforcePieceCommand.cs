using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class PickUpTriforcePieceCommand : ICommand
    {
        private readonly IPlayer link;
        public PickUpTriforcePieceCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.PickUpTriforce();
        }
    }
}

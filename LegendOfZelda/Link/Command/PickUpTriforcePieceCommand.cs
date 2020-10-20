using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class PickUpTriforcePieceCommand : ICommand
    {
        private IPlayer link;
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

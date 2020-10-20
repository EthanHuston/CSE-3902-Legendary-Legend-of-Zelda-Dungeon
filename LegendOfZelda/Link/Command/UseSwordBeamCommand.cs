using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class UseSwordBeamCommand : ICommand
    {
        private IPlayer link;
        public UseSwordBeamCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.UseSwordBeam();
        }
    }
}

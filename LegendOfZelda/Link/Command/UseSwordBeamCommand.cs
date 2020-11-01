using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class UseSwordBeamCommand : ICommand
    {
        private readonly IPlayer link;
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

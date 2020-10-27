using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class UseBoomerangCommand : ICommand
    {
        private readonly IPlayer link;
        public UseBoomerangCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.UseBoomerang();
        }
    }
}

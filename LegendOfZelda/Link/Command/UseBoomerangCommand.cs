using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class UseBoomerangCommand : ICommand
    {
        private IPlayer link;
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

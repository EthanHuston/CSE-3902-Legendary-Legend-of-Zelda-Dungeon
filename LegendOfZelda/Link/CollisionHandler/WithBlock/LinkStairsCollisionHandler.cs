using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkStairsCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            SoundFactory.Instance.CreateStairsSound().Play();
            ((RoomGameState)link.Game.State).MoveRoom(Constants.Direction.Stairs);
        }
    }
}

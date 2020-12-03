using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Utility;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkMovableBlockCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock square, Constants.Direction side)
        {
            MovableSquare squareCast = (MovableSquare)square;

            if (squareCast.HasBeenPushed())
            {
                new LinkImmovableBlockCollisionHandler().HandleCollision(link, square, side);
                return;
            }

            squareCast.Push(UtilityMethods.InvertDirection(side));
            if (UtilityMethods.InvertDirection(side) != squareCast.TriggerDirection) return;
            IDoor doorToOpen = ((RoomGameState)link.Game.State).CurrentRoom.GetDoor(Constants.Direction.Left);
            if (doorToOpen != null) doorToOpen.OpenDoor();
        }
    }
}

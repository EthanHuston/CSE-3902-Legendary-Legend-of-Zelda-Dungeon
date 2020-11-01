using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;

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

            switch (side)
            {
                case Constants.Direction.Up:
                    squareCast.Push(Constants.Direction.Down);
                    break;
                case Constants.Direction.Down:
                    squareCast.Push(Constants.Direction.Up);
                    break;
                case Constants.Direction.Left:
                    squareCast.Push(Constants.Direction.Right);
                    break;
                case Constants.Direction.Right:
                    squareCast.Push(Constants.Direction.Left);
                    break;
            }
        }
    }
}

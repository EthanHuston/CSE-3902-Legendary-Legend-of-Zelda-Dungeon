using LegendOfZelda.Environment;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    class LinkMovableBlockCollisionHandler : ICollisionHandler<IPlayer, INpc>
    {
        public void HandleCollision(IPlayer link, INpc square, Constants.Direction side)
        {
            MovableSquare squareCast = (MovableSquare)square;

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

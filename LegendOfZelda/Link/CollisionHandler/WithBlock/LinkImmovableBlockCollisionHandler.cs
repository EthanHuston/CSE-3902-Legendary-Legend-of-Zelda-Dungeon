using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    class LinkImmovableBlockCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        private const int linkMoveDistance = 1;

        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            Vector2 correctDirection;
            switch(side)
            {
                case Constants.Direction.Up:
                    correctDirection = new Vector2(Constants.LinkNoMove, Constants.LinkMoveUp);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                case Constants.Direction.Down:
                    correctDirection = new Vector2(Constants.LinkNoMove, Constants.LinkMoveDown);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                case Constants.Direction.Left:
                    correctDirection = new Vector2(Constants.LinkMoveLeft, Constants.LinkNoMove);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                case Constants.Direction.Right:
                    correctDirection = new Vector2(Constants.LinkMoveRight, Constants.LinkNoMove);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                default:
                    break;
            }
        }
    }
}

using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkBlockCollisionHandler : ICollision<IPlayer, IBlock>
    {
        public void HandleCollison(IPlayer link, IBlock block, Constants.Direction side)
        {
            Vector2 correctDirection;
            switch(side)
            {
                case Constants.Direction.Up:
                    correctDirection = new Vector2(Constants.LinkNoMove, Constants.LinkMoveUp);
                    link.Move(1, correctDirection);
                    break;
                case Constants.Direction.Down:
                    correctDirection = new Vector2(Constants.LinkNoMove, Constants.LinkMoveDown);
                    link.Move(1, correctDirection);
                    break;
                case Constants.Direction.Left:
                    correctDirection = new Vector2(Constants.LinkMoveLeft, Constants.LinkNoMove);
                    link.Move(1, correctDirection);
                    break;
                case Constants.Direction.Right:
                    correctDirection = new Vector2(Constants.LinkMoveRight, Constants.LinkNoMove);
                    link.Move(1, correctDirection);
                    break;
                default:
                    break;
            }
        }
    }
}

using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkMoveableBlockCollisionHandler : ICollision<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            Vector2 correctDirection;
            switch (side)
            {
                case Constants.Direction.Up:
                    correctDirection = new Vector2(Constants.MBlockNoMove, Constants.MBlockMoveDown);
                    block.Move(1, correctDirection);
                    break;
                case Constants.Direction.Down:
                    correctDirection = new Vector2(Constants.MBlockNoMove, Constants.MBlockMoveUp);
                    block.Move(1, correctDirection);
                    break;
                case Constants.Direction.Left:
                    correctDirection = new Vector2(Constants.MBlockMoveRight, Constants.MBlockNoMove);
                    block.Move(1, correctDirection);
                    break;
                case Constants.Direction.Right:
                    correctDirection = new Vector2(Constants.MBlockMoveLeft, Constants.MBlockNoMove);
                    block.Move(1, correctDirection);
                    break;
                default:
                    break;
            }
        }
    }
}

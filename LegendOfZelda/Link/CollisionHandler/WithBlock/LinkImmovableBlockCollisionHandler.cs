using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkImmovableBlockCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        private const int linkMoveDistance = 1;

        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            Vector2 correctDirection;
            switch (side)
            {
                case Constants.Direction.Up:
                    correctDirection = new Vector2(0, -1);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                case Constants.Direction.Down:
                    correctDirection = new Vector2(0, 1);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                case Constants.Direction.Left:
                    correctDirection = new Vector2(-1, 0);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                case Constants.Direction.Right:
                    correctDirection = new Vector2(1, 0);
                    link.Move(linkMoveDistance, correctDirection);
                    break;
                default:
                    break;
            }
        }
    }
}

using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithBlock
{
    internal class SkeletonBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
    {
        public void HandleCollision(INpc enemy, IBlock block, Constants.Direction side)
        {
            Vector2 correctDirection;
            enemy.SetKnockBack(false, Constants.Direction.Up);
            switch (side)
            {
                case Constants.Direction.Up:
                    correctDirection = new Vector2(Constants.EnemyNoMove, Constants.EnemyMoveUp);
                    enemy.Move(correctDirection);
                    break;
                case Constants.Direction.Down:
                    correctDirection = new Vector2(Constants.EnemyNoMove, Constants.EnemyMoveDown);
                    enemy.Move(correctDirection);
                    break;
                case Constants.Direction.Left:
                    correctDirection = new Vector2(Constants.EnemyMoveLeft, Constants.EnemyNoMove);
                    enemy.Move(correctDirection);
                    break;
                case Constants.Direction.Right:
                    correctDirection = new Vector2(Constants.EnemyMoveRight, Constants.EnemyNoMove);
                    enemy.Move(correctDirection);
                    break;
                default:
                    break;

            }

        }
    }
}

using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Enemies.CollisionHandlers
{
    class SpikeTrapBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
    {
        public void HandleCollision(INpc enemy, IBlock block, Constants.Direction side)
        {
            //Here only in the case a moveable block is moved in the way of the trap.
            Vector2 correctDirection;
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

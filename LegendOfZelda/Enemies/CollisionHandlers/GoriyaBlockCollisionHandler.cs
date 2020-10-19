using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Enemies.CollisionHandlers
{
    class GoriyaBlockCollisionHandler : ICollision <INpc, IBlock>
    {
        public void HandleCollison(INpc enemy, IBlock block, Constants.Direction side)
        {
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

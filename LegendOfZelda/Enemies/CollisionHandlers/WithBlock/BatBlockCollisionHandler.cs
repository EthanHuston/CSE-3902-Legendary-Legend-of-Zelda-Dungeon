using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithBlock
{
    internal class BatBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
    {
        public void HandleCollision(INpc enemy, IBlock block, Constants.Direction side)
        {
            if (CheckCollision(block.GetType()))
            {
                Vector2 direction = new Vector2();
                switch (side)
                {
                    case Constants.Direction.Up:
                        direction = new Vector2(Constants.EnemyNoMove, Constants.EnemyMoveUp);
                        break;
                    case Constants.Direction.Down:
                        direction = new Vector2(Constants.EnemyNoMove, Constants.EnemyMoveDown);
                        break;
                    case Constants.Direction.Right:
                        direction = new Vector2(Constants.EnemyMoveRight, Constants.EnemyNoMove);
                        break;
                    case Constants.Direction.Left:
                        direction = new Vector2(Constants.EnemyMoveLeft, Constants.EnemyNoMove);
                        break;
                }
                ((Bat)enemy).ChooseDirection();
                ((Bat)enemy).Move(direction);
            }
        }

        private bool CheckCollision(Type blockType)
        {
            return
                blockType == typeof(RoomWall) ||
                blockType == typeof(BombableOpening) ||
                blockType == typeof(Walls) ||
                blockType == typeof(OpenedDoor) ||
                blockType == typeof(LockedDoor) ||
                blockType == typeof(ShutDoor);
        }
    }
}

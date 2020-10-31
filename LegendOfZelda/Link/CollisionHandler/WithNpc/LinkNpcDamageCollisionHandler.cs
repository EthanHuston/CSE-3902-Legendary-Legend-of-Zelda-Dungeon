using LegendOfZelda.Enemies;
using LegendOfZelda.GameLogic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler.WithNpc
{
    internal class LinkNpcDamageCollisionHandler : ICollisionHandler<IPlayer, INpc>
    {
        private const int knockbackDistance = 50;
        private const int knockbackVelocityScalar = 3;

        public void HandleCollision(IPlayer link, INpc enemy, Constants.Direction side)
        {
            link.BeDamaged(enemy.GetDamageAmount());

            Vector2 velocity = Vector2.Zero;

            switch (side)
            {
                case Constants.Direction.Up:
                    velocity = new Vector2(0, -1 * knockbackVelocityScalar);
                    break;
                case Constants.Direction.Down:
                    velocity = new Vector2(0, knockbackVelocityScalar);
                    break;
                case Constants.Direction.Left:
                    velocity = new Vector2(-1 * knockbackVelocityScalar, 0);
                    break;
                case Constants.Direction.Right:
                    velocity = new Vector2(knockbackVelocityScalar, 0);
                    break;
            }

            link.Move(knockbackDistance, velocity);
        }
    }
}

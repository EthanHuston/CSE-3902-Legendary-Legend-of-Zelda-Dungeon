using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class ArrowFlyingProjectile : GenericProjectile
    {
        private const int moveDistanceInterval = 5;

        public ArrowFlyingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.Direction direction, Constants.ItemOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            switch (direction)
            {
                case Constants.Direction.Down:
                    Velocity = new Vector2(0, moveDistanceInterval);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowDownSprite();
                    break;
                case Constants.Direction.Up:
                    Velocity = new Vector2(0, -1 * moveDistanceInterval);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowUpSprite();
                    break;
                case Constants.Direction.Right:
                    Velocity = new Vector2(moveDistanceInterval, 0);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowRightSprite();
                    break;
                case Constants.Direction.Left:
                    Velocity = new Vector2(-1 * moveDistanceInterval, 0);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowLeftSprite();
                    break;
            }
        }

        public override void Update()
        {
            Mover.Update();
        }
        public override void Draw()
        {
            sprite.Draw(spriteBatch, Position);
        }

        public override double DamageAmount()
        {
            return Constants.ArrowDamage;
        }
    }
}

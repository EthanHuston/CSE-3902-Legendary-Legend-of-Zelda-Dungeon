using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class ArrowFlyingProjectile : GenericProjectile
    {
        public ArrowFlyingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ProjectileOwner owner, Vector2 velocity) : base(spriteBatch, spawnPosition, owner)
        {
            projectileType = Link.LinkConstants.ProjectileType.Arrow;
            Velocity = velocity;

            if (Velocity.X == 0)
            {
                sprite = Velocity.Y > 0 ?
                    ProjectileSpriteFactory.Instance.CreateArrowDownSprite() :
                    ProjectileSpriteFactory.Instance.CreateArrowUpSprite();
            }
            else
            {
                sprite = Velocity.X > 0 ?
                    ProjectileSpriteFactory.Instance.CreateArrowRightSprite() :
                    ProjectileSpriteFactory.Instance.CreateArrowLeftSprite();
            }
        }

        public override void Update()
        {
            Mover.Update();
            sprite.Update();
        }

        public override double DamageAmount()
        {
            return Constants.ArrowDamage;
        }
    }
}

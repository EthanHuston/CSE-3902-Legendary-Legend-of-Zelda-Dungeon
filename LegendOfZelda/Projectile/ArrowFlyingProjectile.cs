using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class ArrowFlyingProjectile : GenericProjectile
    {
        private const int moveDistanceInterval = 2;

        public ArrowFlyingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ProjectileOwner owner, Vector2 velocity) : base(spriteBatch, spawnPosition, owner)
        {
            Velocity = velocity;
            
            if(Velocity.X == 0)
            {
                sprite = Velocity.Y > 0 ? 
                    ProjectileSpriteFactory.Instance.CreateArrowDownSprite() : 
                    ProjectileSpriteFactory.Instance.CreateArrowUpSprite();
            } else
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

using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class SwordAttackingProjectile : GenericProjectile
    {
        public SwordAttackingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.Direction direction, Constants.ProjectileOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            projectileType = LinkConstants.ProjectileType.Sword;
            Velocity = Vector2.Zero;
            switch (direction)
            {
                case Constants.Direction.Down:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingDownSprite();
                    break;
                case Constants.Direction.Up:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingUpSprite();
                    break;
                case Constants.Direction.Right:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingRightSprite();
                    break;
                case Constants.Direction.Left:
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackingLeftSprite();
                    break;
            }
        }

        public override void Update()
        {
            Mover.Update();
            sprite.Update();
            CheckItemIsExpired();
        }

        public override void Draw()
        {
            sprite.Draw(spriteBatch, Position);
        }

        protected void CheckItemIsExpired()
        {
            itemIsExpired = sprite.FinishedAnimation();
        }

        public override double DamageAmount()
        {
            return Constants.SwordDamage;
        }
    }
}

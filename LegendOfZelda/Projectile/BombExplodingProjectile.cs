using LegendOfZelda.Projectile.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class BombExplodingProjectile : GenericProjectile
    {
        public BombExplodingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ProjectileOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            sprite = ProjectileSpriteFactory.Instance.CreateBombExplodingSprite();
        }

        public override void Update()
        {
            Mover.Update();
            sprite.Update();
            CheckItemIsExpired();
        }

        private void CheckItemIsExpired()
        {
            itemIsExpired = sprite.FinishedAnimation();
        }

        public bool IsExploded()
        {
            return ((BombExplodingSprite)sprite).IsExploding();
        }

        public override double DamageAmount()
        {
            return Constants.BombDamage;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class BombExplodingProjectile : GenericProjectile
    {
        public BombExplodingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ItemOwner owner) : base(spriteBatch, spawnPosition, owner)
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
            return sprite.FinishedAnimation();
        }

        public override double DamageAmount()
        {
            return Constants.BombDamage;
        }
    }
}

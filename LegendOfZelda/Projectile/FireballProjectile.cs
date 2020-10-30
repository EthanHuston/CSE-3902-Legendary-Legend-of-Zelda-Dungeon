using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class FireballProjectile : GenericProjectile
    {

        public FireballProjectile(SpriteBatch spriteBatch, Point spawnPosition, Vector2 velocity, Constants.ProjectileOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            sprite = ProjectileSpriteFactory.Instance.CreateFireballSprite();
            Position = spawnPosition;
            Velocity = velocity;
        }

        public override double DamageAmount()
        {
            return Constants.FireballDamage;
        }

        override public void Update()
        {
            Mover.Update();
            sprite.Update();
        }
    }
}

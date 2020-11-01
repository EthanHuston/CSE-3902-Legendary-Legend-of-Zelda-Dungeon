using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class FireballProjectile : GenericProjectile
    {

        public FireballProjectile(SpriteBatch spriteBatch, Point spawnPosition, Vector2 velocity, Constants.ProjectileOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            sprite = ProjectileSpriteFactory.Instance.CreateFireballSprite();
            Position = spawnPosition;
            Velocity = velocity;
            projectileType = LinkConstants.ProjectileType.Fireball;
        }

        public override double DamageAmount()
        {
            return Constants.FireballDamage;
        }

        public override void Update()
        {
            Mover.Update();
            sprite.Update();
        }
    }
}

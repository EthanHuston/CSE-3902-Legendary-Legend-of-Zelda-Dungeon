using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class Fireball : GenericProjectile
    {

        public Fireball(SpriteBatch spriteBatch, Point spawnPosition, Vector2 velocity, Constants.ItemOwner owner) : base(spriteBatch, spawnPosition, owner)
        {
            sprite = SpriteFactory.Instance.CreateFireballSprite();
            position.X = spawnPosition.X;
            position.Y = spawnPosition.Y;
            this.velocity.X = velocity.X;
            this.velocity.Y = velocity.Y;
        }

        public override Vector2 GetVelocity()
        {
            return new Vector2(velocity.X, velocity.Y);
        }

        override public void Update()
        {
            position.X += (int) velocity.X;
            position.Y += (int) velocity.Y;
            sprite.Update();
            CheckItemIsExpired();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // put some condition that gets checked
        }
    }
}

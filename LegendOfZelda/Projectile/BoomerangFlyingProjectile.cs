using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class BoomerangFlyingProjectile : GenericProjectile
    {
        private bool returningToOwner;
        private ISpawnable itemToTrack;
        private const int despawnMaxXFromOwner = 15;
        private const int despawnMinXFromOwner = 0;
        private const int despawnMaxYFromOwner = 15;
        private const int despawnMinYFromOwner = 0;
        private const int maxDistanceFromOwner = 300;

        public BoomerangFlyingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ItemOwner owner, ISpawnable itemToTrack, Vector2 velocity) : base(spriteBatch, spawnPosition, owner)
        {
            sprite = ProjectileSpriteFactory.Instance.CreateBoomerangFlyingSprite();
            this.velocity.X = velocity.X;
            this.velocity.Y = velocity.Y;
            returningToOwner = false;
            this.itemToTrack = itemToTrack;
        }

        public override void Update()
        {
            MoveBoomerang();
            CheckItemIsExpired();
            sprite.Update();
        }

        private void MoveBoomerang()
        {
            if (GetDistanceFromOwner() > maxDistanceFromOwner || Utility.ItemIsOutOfBounds(position))
            {
                returningToOwner = true;
                velocity.X *= -1;
                velocity.Y *= -1;
            }

            position.X = position.X == 0 ? itemToTrack.GetPosition().X : (int)(position.X + velocity.X);
            position.Y = position.Y == 0 ? itemToTrack.GetPosition().Y : (int)(position.Y + velocity.Y);
        }

        private double GetDistanceFromOwner()
        {
            return Utility.GetDistance(position, itemToTrack.GetPosition());
        }

        protected override void CheckItemIsExpired()
        {
            Point ownerPosition = itemToTrack.GetPosition();
            itemIsExpired = returningToOwner &&
                position.X <= ownerPosition.X + despawnMaxXFromOwner &&
                position.X >= ownerPosition.X + despawnMinXFromOwner &&
                position.Y <= ownerPosition.Y + despawnMaxYFromOwner &&
                position.Y >= ownerPosition.Y + despawnMinYFromOwner;
        }

        public override Vector2 GetVelocity()
        {
            // this is not true velocity, as X xor Y will always be 0; but shouldn't matter :)
            return new Vector2(velocity.X, velocity.Y);
        }
        public override double DamageAmount()
        {
            return Constants.BoomerangDamage;
        }
    }
}

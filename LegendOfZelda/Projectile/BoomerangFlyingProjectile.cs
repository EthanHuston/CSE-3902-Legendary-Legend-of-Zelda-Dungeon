using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
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
            Velocity = velocity;
            returningToOwner = false;
            this.itemToTrack = itemToTrack;
        }

        public override void Update()
        {
            MoveBoomerang();
            CheckItemIsExpired();
            sprite.Update();
            Mover.Update();
        }

        private void MoveBoomerang()
        {
            if (GetDistanceFromOwner() > maxDistanceFromOwner || UtilityMethods.ItemIsOutOfBounds(Position))
            {
                returningToOwner = true;
                Velocity = new Vector2(Velocity.X * -1, Velocity.Y * -1);
            }

            int posX = Position.X == 0 ? itemToTrack.Position.X : (int)(Position.X + Velocity.X);
            int posY = Position.Y == 0 ? itemToTrack.Position.Y : (int)(Position.Y + Velocity.Y);
            Position = new Point(posX, posX);
        }

        private double GetDistanceFromOwner()
        {
            return UtilityMethods.GetDistance(Position, itemToTrack.Position);
        }

        protected override void CheckItemIsExpired()
        {
            Point ownerPosition = itemToTrack.Position;
            itemIsExpired = returningToOwner &&
                Position.X <= ownerPosition.X + despawnMaxXFromOwner &&
                Position.X >= ownerPosition.X + despawnMinXFromOwner &&
                Position.Y <= ownerPosition.Y + despawnMaxYFromOwner &&
                Position.Y >= ownerPosition.Y + despawnMinYFromOwner;
        }

        public override double DamageAmount()
        {
            return Constants.BoomerangDamage;
        }
    }
}

using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    internal class BoomerangFlyingProjectile : GenericProjectile
    {
        private bool returningToOwner;
        private readonly ISpawnable itemToTrack;
        private const int despawnMaxXFromOwner = 15;
        private const int despawnMinXFromOwner = 0;
        private const int despawnMaxYFromOwner = 15;
        private const int despawnMinYFromOwner = 0;
        private const int maxDistanceFromOwner = (int) (Constants.GameScaler * 100);

        public BoomerangFlyingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ProjectileOwner owner, ISpawnable itemToTrack, Vector2 velocity) : base(spriteBatch, spawnPosition, owner)
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
            if (!returningToOwner && GetDistanceFromOwner() > maxDistanceFromOwner)
            {
                ReturnToOwner();
            }

            int posX = Velocity.X == 0 ? itemToTrack.Position.X + itemToTrack.GetRectangle().Width / 2 : (int)(Position.X + Velocity.X);
            int posY = Velocity.Y == 0 ? itemToTrack.Position.Y + itemToTrack.GetRectangle().Height / 2 : (int)(Position.Y + Velocity.Y);
            Position = new Point(posX, posY);
        }

        private double GetDistanceFromOwner()
        {
            return UtilityMethods.GetDistance(Position, itemToTrack.Position);
        }

        private void CheckItemIsExpired()
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

        public void ReturnToOwner()
        {
            if (returningToOwner) return;
            returningToOwner = true;
            Velocity = new Vector2(Velocity.X * -1, Velocity.Y * -1);
        }
    }
}

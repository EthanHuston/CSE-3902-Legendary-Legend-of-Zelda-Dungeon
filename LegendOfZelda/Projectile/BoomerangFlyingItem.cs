using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Item
{
    class BoomerangFlyingItem : GenericProjectile
    {
        private bool returningToLink;
        private Constants.Direction direction;
        private ISpawnable itemToTrack;
        private Point oldPosition;
        private const int moveDistanceInterval = 5;
        private const int despawnMaxXFromOwner = 15;
        private const int despawnMinXFromOwner = 0;
        private const int despawnMaxYFromOwner = 15;
        private const int despawnMinYFromOwner = 0;
        private const int maxDistanceFromOwner = 300;

        public BoomerangFlyingItem(Game1 game, Point spawnPosition, Constants.ItemOwner owner, ISpawnable itemToTrack, Constants.Direction direction) : base(game, spawnPosition, owner)
        {
            sprite = SpriteFactory.Instance.CreateBoomerangFlyingSprite();
            this.direction = direction;
            returningToLink = false;
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
            if (!returningToLink)
            {
                returningToLink = GetDistanceFromLink() > maxDistanceFromOwner || Utility.ItemIsOutOfBounds(position);
            }

            oldPosition.X = position.X;
            oldPosition.Y = position.Y;

            switch (direction)
            {
                case Constants.Direction.Up:
                    position.X = itemToTrack.GetPosition().X;
                    position.Y += moveDistanceInterval * (returningToLink ? 1 : -1);
                    break;
                case Constants.Direction.Down:
                    position.X = itemToTrack.GetPosition().X;
                    position.Y += moveDistanceInterval * (returningToLink ? -1 : 1);
                    break;
                case Constants.Direction.Right:
                    position.X += moveDistanceInterval * (returningToLink ? -1 : 1);
                    position.Y = itemToTrack.GetPosition().Y;
                    break;
                case Constants.Direction.Left:
                    position.X += moveDistanceInterval * (returningToLink ? 1 : -1);
                    position.Y = itemToTrack.GetPosition().Y;
                    break;
            }
        }

        private double GetDistanceFromLink()
        {
            return Utility.GetDistance(position, itemToTrack.GetPosition());
        }

        protected override void CheckItemIsExpired()
        {
            Point ownerPosition = itemToTrack.GetPosition();
            itemIsExpired = returningToLink &&
                position.X <= ownerPosition.X + despawnMaxXFromOwner &&
                position.X >= ownerPosition.X + despawnMinXFromOwner &&
                position.Y <= ownerPosition.Y + despawnMaxYFromOwner &&
                position.Y >= ownerPosition.Y + despawnMinYFromOwner;
        }

        public override Vector2 GetVelocity()
        {
            return Vector2.Subtract(position.ToVector2(), oldPosition.ToVector2());
        }
    }
}

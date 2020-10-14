using Microsoft.Xna.Framework;

namespace LegendOfZelda.Item
{
    class ArrowFlyingItem : GenericProjectile
    {
        private const int moveDistanceInterval = 5;

        public ArrowFlyingItem(Game1 game, Point spawnPosition, Constants.Direction direction, Constants.ItemOwner owner) : base(game, spawnPosition, owner)
        {
            switch (direction)
            {
                case Constants.Direction.Down:
                    velocity = new Vector2(0, moveDistanceInterval);
                    sprite = SpriteFactory.Instance.CreateArrowDownSprite();
                    break;
                case Constants.Direction.Up:
                    velocity = new Vector2(0, -1 * moveDistanceInterval);
                    sprite = SpriteFactory.Instance.CreateArrowUpSprite();
                    break;
                case Constants.Direction.Right:
                    velocity = new Vector2(moveDistanceInterval, 0);
                    sprite = SpriteFactory.Instance.CreateArrowRightSprite();
                    break;
                case Constants.Direction.Left:
                    velocity = new Vector2(-1 * moveDistanceInterval, 0);
                    sprite = SpriteFactory.Instance.CreateArrowLeftSprite();
                    break;
            }
        }

        public override void Update()
        {
            position.X += (int)velocity.X;
            position.Y += (int)velocity.Y;

            CheckItemIsExpired();
        }
        public override void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public override Vector2 GetVelocity()
        {
            return new Vector2(velocity.X, velocity.Y);
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = Utility.ItemIsOutOfBounds(position); // or item hits enemy, but not yet implemented
        }
    }
}

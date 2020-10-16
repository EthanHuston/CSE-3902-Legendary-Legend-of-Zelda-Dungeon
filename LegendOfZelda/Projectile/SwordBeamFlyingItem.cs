using LegendOfZelda.Item;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Item
{
    class SwordBeamFlyingItem : GenericProjectile
    {
        private bool stopMovingAndExplode;
        private bool updatedSprite;
        private const int moveDistanceInterval = 5;

        public SwordBeamFlyingItem(Game1 game, Point spawnPosition, Constants.ItemOwner owner, Constants.Direction direction) : base(game, spawnPosition, owner)
        {
            updatedSprite = false; // true we update sword beam to be exploding -- just so we don't update it more than once
            stopMovingAndExplode = false; // true the sword beam hits an enemy or gets to edge of screen
            switch (direction)
            {
                case Constants.Direction.Down:
                    velocity = new Vector2(0, moveDistanceInterval);
                    sprite = SpriteFactory.Instance.CreateSwordBeamDownSprite();
                    break;
                case Constants.Direction.Up:
                    velocity = new Vector2(0, -1 * moveDistanceInterval);
                    sprite = SpriteFactory.Instance.CreateSwordBeamUpSprite();
                    break;
                case Constants.Direction.Right:
                    velocity = new Vector2(moveDistanceInterval, 0);
                    sprite = SpriteFactory.Instance.CreateSwordBeamRightSprite();
                    break;
                case Constants.Direction.Left:
                    velocity = new Vector2(-1 * moveDistanceInterval, 0);
                    sprite = SpriteFactory.Instance.CreateSwordBeamLeftSprite();
                    break;
            }
        }

        public override void Update()
        {
            sprite.Update();
            if (!stopMovingAndExplode)
            {
                position.X += (int)velocity.X;
                position.Y += (int)velocity.Y;
                // TODO: remove me after Sprint 2 - just so we can see the sword exploding
                // Really, we'd want sword beam to explode once it a) hits wall OR b) hits enemy
                stopMovingAndExplode = Utility.ItemIsOutOfBounds(position); // or item hits enemy, but not yet implemented
            }
            else if (stopMovingAndExplode && !updatedSprite) // initial setup of sword beam explosion
            {
                sprite = SpriteFactory.Instance.CreateSwordBeamExplodingSprite();
                updatedSprite = true;
            }
            CheckItemIsExpired();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = sprite.FinishedAnimation();
        }

        public override Vector2 GetVelocity()
        {
            return new Vector2(velocity.X, velocity.Y);
        }
    }
}

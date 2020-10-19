using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile
{
    class SwordBeamFlyingProjectile : GenericProjectile
    {
        private bool stopMovingAndExplode;
        private bool updatedSprite;
        private const int moveDistanceInterval = 5;

        public SwordBeamFlyingProjectile(SpriteBatch spriteBatch, Point spawnPosition, Constants.ItemOwner owner, Constants.Direction direction) : base(spriteBatch, spawnPosition, owner)
        {
            updatedSprite = false; // true we update sword beam to be exploding -- just so we don't update it more than once
            stopMovingAndExplode = false; // true the sword beam hits an enemy or gets to edge of screen
            switch (direction)
            {
                case Constants.Direction.Down:
                    velocity = new Vector2(0, moveDistanceInterval);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamDownSprite();
                    break;
                case Constants.Direction.Up:
                    velocity = new Vector2(0, -1 * moveDistanceInterval);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamUpSprite();
                    break;
                case Constants.Direction.Right:
                    velocity = new Vector2(moveDistanceInterval, 0);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamRightSprite();
                    break;
                case Constants.Direction.Left:
                    velocity = new Vector2(-1 * moveDistanceInterval, 0);
                    sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamLeftSprite();
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
                stopMovingAndExplode = Utility.ItemIsOutOfBounds(position);
            }
            else if (stopMovingAndExplode && !updatedSprite) // initial setup of sword beam explosion
            {
                sprite = ProjectileSpriteFactory.Instance.CreateSwordBeamExplodingSprite();
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

        public void ExplodeSword()
        {
            stopMovingAndExplode = true;
        }
        public override double DamageAmount()
        {
            return Constants.SwordBeamDamage;
        }
    }
}

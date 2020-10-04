using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Item
{
    class SwordBeamItem : ILinkItem
    {
        private bool itemIsExpired;
        private bool stopMovingAndExplode;
        private bool updatedSprite;
        private Vector2 direction;
        private Vector2 position;
        private ILinkItemSprite sprite;
        private SpriteBatch spriteBatch;
        private Link link;
        private const Constants.Item type = Constants.Item.SwordBeam;

        public SwordBeamItem(Link link, Constants.Direction direction)
        {
            this.link = link;
            this.spriteBatch = link.Game.SpriteBatch;
            updatedSprite = false; // true we update sword beam to be exploding -- just so we don't update it more than once
            stopMovingAndExplode = false; // true the sword beam hits an enemy or gets to edge of screen
            position.X = link.GetPosition().X + Constants.SwordBeamSpawnXOffsetFromLink;
            position.Y = link.GetPosition().Y + Constants.SwordBeamSpawnYOffsetFromLink;
            switch (direction)
            {
                case Constants.Direction.Down:
                    this.direction = new Vector2(0, 1);
                    sprite = LinkSpriteFactory.Instance.CreateSwordBeamDownSprite();
                    break;
                case Constants.Direction.Up:
                    this.direction = new Vector2(0, -1);
                    sprite = LinkSpriteFactory.Instance.CreateSwordBeamUpSprite();
                    break;
                case Constants.Direction.Right:
                    this.direction = new Vector2(1, 0);
                    sprite = LinkSpriteFactory.Instance.CreateSwordBeamRightSprite();
                    break;
                case Constants.Direction.Left:
                    this.direction = new Vector2(-1, 0);
                    sprite = LinkSpriteFactory.Instance.CreateSwordBeamLeftSprite();
                    break;
            }
        }

        public void Update()
        {
            sprite.Update();
            if (!stopMovingAndExplode)
            {
                position.X += Constants.SwordBeamFlyingDistanceInterval * direction.X;
                position.Y += Constants.SwordBeamFlyingDistanceInterval * direction.Y;
                // TODO: remove me after Sprint 2 - just so we can see the sword exploding
                stopMovingAndExplode = Utility.GetDistance(position, link.GetPosition()) > Constants.SwordBeamMaxDistanceFromLink;
            }
            else if (stopMovingAndExplode && !updatedSprite) // initial setup of sword beam explosion
            {
                sprite = LinkSpriteFactory.Instance.CreateSwordBeamExplodingSprite();
                updatedSprite = true;
            }

            // TODO: Uncomment me after Sprint 2
            // stopMovingAndExplode = Utility.ItemIsOutOfBounds(position); // or item hits enemy, but not yet implemented
            itemIsExpired = sprite.FinishedAnimation(); // when explosion finishes animating
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public Constants.Item GetItemType()
        {
            return type;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Item
{
    class ArrowFlyingItem : ILinkItem
    {
        private bool itemIsExpired;
        private Vector2 direction;
        private Vector2 position;
        private ILinkItemSprite sprite;
        private SpriteBatch spriteBatch;
        private const Constants.Item type = Constants.Item.Arrow;

        public ArrowFlyingItem(Link link, Constants.Direction direction)
        {
            this.spriteBatch = link.Game.SpriteBatch;
            position.X = link.GetPosition().X + Constants.ArrowSpawnXOffsetFromLink;
            position.Y = link.GetPosition().Y + Constants.ArrowSpawnYOffsetFromLink;
            switch (direction) {
                case Constants.Direction.Down:
                    this.direction = new Vector2(0, 1);
                    sprite = LinkSpriteFactory.Instance.CreateArrowDownSprite();
                    break;
                case Constants.Direction.Up:
                    this.direction = new Vector2(0, -1);
                    sprite = LinkSpriteFactory.Instance.CreateArrowUpSprite();
                    break;
                case Constants.Direction.Right:
                    this.direction = new Vector2(1, 0);
                    sprite = LinkSpriteFactory.Instance.CreateArrowRightSprite();
                    break;
                case Constants.Direction.Left:
                    this.direction = new Vector2(-1, 0);
                    sprite = LinkSpriteFactory.Instance.CreateArrowLeftSprite();
                    break;
            }
        }

        public void Update()
        {
            position.X += Constants.ArrowFlyingDistanceInterval * direction.X;
            position.Y += Constants.ArrowFlyingDistanceInterval * direction.Y;

            itemIsExpired = Utility.ItemIsOutOfBounds(position); // or item hits enemy, but not yet implemented
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

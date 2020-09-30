using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Items
{
    class BombExploding : ILinkItem
    {
        private bool itemIsExpired;
        private Vector2 direction;
        private Vector2 position;
        private ILinkItemSprite sprite;
        private SpriteBatch spriteBatch;
        private const Constants.Items type = Constants.Items.Arrow;

        public BombExploding(Link link)
        {
            this.position = new Vector2();
            this.spriteBatch = link.Game.SpriteBatch;
            position.X = link.GetPosition().X + Constants.BombSpawnXOffsetFromLink;
            position.Y = link.GetPosition().Y + Constants.BombSpawnYOffsetFromLink;
            sprite = LinkSpriteFactory.Instance.CreateBombExplodingSprite();
        }

        public void Update()
        {
            itemIsExpired = sprite.FinishedAnimation();
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public Constants.Items GetItemType()
        {
            return type;
        }
    }
}

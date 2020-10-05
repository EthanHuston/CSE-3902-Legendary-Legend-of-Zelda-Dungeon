using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Item
{
    class BombExplodingItem : ILinkItem
    {
        private bool itemIsExpired;
        private Vector2 position;
        private ILinkItemSprite sprite;
        private SpriteBatch spriteBatch;
        private const Constants.Item type = Constants.Item.Arrow;

        public BombExplodingItem(LinkPlayer link)
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

        public Constants.Item GetItemType()
        {
            return type;
        }
    }
}

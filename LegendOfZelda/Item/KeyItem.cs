using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class KeyItem : GenericItem
    {
        public KeyItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateKeySprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = !itemIsExpired && false;
        }
    }
}

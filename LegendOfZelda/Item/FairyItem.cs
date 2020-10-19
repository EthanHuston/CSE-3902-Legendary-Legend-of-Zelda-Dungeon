using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class FairyItem : GenericItem
    {
        public FairyItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateFairySprite(spawnPosition);
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = !itemIsExpired && false;
        }
    }
}

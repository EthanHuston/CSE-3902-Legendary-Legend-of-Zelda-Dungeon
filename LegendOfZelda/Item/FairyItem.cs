using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class FairyItem : GenericItem
    {
        public FairyItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateFairySprite(spawnPosition);
            itemType = LinkConstants.ItemType.Fairy;
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = itemIsExpired && true;
        }
    }
}

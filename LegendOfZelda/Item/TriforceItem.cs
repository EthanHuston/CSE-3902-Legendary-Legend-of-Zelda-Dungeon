using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class TriforceItem : GenericItem
    {
        public TriforceItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateTriforceSprite();
            itemType = LinkConstants.ItemType.Triforce;
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = itemIsExpired && true;
        }
    }
}

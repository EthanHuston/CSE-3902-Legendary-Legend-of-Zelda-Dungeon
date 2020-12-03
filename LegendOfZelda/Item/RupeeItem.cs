using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class RupeeItem : GenericItem
    {
        public RupeeItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateRupeeSprite();
            itemType = LinkConstants.ItemType.Rupee;
        }
    }
}

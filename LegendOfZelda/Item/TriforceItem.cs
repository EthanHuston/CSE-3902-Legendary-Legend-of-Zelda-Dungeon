using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class TriforceItem : GenericItem
    {
        public TriforceItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateTriforceSprite();
            itemType = LinkConstants.ItemType.Triforce;
        }
    }
}

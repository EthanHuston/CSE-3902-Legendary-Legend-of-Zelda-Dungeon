using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class BoomerangItem : GenericItem
    {
        public BoomerangItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateBoomerangSprite();
            itemType = LinkConstants.ItemType.Boomerang;
        }
    }
}

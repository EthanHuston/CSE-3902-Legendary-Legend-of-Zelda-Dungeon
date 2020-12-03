using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class HeartContainerItem : GenericItem
    {
        public HeartContainerItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateHeartContainerSprite();
            itemType = LinkConstants.ItemType.HeartContainer;
        }
    }
}

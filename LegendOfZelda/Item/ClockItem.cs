using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class ClockItem : GenericItem
    {
        public ClockItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateClockSprite();
            itemType = LinkConstants.ItemType.Clock;
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = itemIsExpired && true;
        }
    }
}

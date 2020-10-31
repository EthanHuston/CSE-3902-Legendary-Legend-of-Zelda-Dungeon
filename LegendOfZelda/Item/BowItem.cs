using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class BowItem : GenericItem
    {
        public BowItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateBowSprite();
            itemType = LinkConstants.ItemType.Bow;
        }

        protected override void CheckItemIsExpired()
        {
            // put a condition here if we want item to despawn after something happens (i.e. some time passes)
            // eventually, we'll probably want it to despawn when Link runs through it
            itemIsExpired = itemIsExpired && true;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class BoomerangItem : GenericItem
    {
        public BoomerangItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateBoomerangSprite();
        }

        protected override void CheckItemIsExpired()
        {
            // change to true when we want item to despawn (after link picks up, after certain time, etc.)
            itemIsExpired = itemIsExpired && true;
        }
    }
}

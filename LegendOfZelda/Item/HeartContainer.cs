using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class HeartContainer : GenericItem
    {
        public HeartContainer(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateHeartContainerSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = !itemIsExpired && false;
        }
    }
}

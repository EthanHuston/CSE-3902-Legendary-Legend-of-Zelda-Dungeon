using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class CompassItem : GenericItem
    {
        public CompassItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateCompassSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = !itemIsExpired && false;
        }
    }
}

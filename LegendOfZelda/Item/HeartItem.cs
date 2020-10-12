using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class HeartItem : GenericItem
    {
        public HeartItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateHeartSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // condition here to determine when to despawn item
        }
    }
}

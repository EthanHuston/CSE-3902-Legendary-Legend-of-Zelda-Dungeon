using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class TriforceItem : GenericItem
    {
        public TriforceItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateTriforceSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // change to true w/ condition to despawn item
        }
    }
}

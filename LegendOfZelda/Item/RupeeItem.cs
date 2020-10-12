using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class RupeeItem : GenericItem
    {
        public RupeeItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateRupeeSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // add condition to determine when to despawn item
        }
    }
}

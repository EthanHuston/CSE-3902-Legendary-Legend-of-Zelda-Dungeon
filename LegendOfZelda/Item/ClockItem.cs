using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class ClockItem : GenericItem
    {
        public ClockItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateClockSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // change to true when we want item to despawn
        }
    }
}

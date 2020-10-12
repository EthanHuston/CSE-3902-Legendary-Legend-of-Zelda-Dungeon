using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class BowItem : GenericItem
    {
        public BowItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateBowSprite();
        }

        protected override void CheckItemIsExpired()
        {
            // put a condition here if we want item to despawn after something happens (i.e. some time passes)
            // eventually, we'll probably want it to despawn when Link runs through it
            itemIsExpired = false;
        }
    }
}

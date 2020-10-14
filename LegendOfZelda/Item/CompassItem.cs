using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class CompassItem : GenericItem
    {
        public CompassItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateCompassSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // change to true to despawn item
        }
    }
}

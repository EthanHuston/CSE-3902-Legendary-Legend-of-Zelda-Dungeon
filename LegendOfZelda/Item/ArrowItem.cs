using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    class ArrowItem : GenericItem
    {
        public ArrowItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateArrowSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // put code here if we want it to despawn after a certain amount of time
        }
    }
}

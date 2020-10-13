using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class KeyItem : GenericItem
    {
        public KeyItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateKeySprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // condition here to determine when to despawn item
        }
    }
}

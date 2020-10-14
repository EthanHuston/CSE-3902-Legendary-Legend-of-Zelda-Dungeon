using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class MapItem : GenericItem
    {
        public MapItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateMapSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // add condition here to determine when to despawn item
        }
    }
}

using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class FairyItem : GenericItem
    {
        public FairyItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = SpriteFactory.Instance.CreateFairySprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = false; // put condition here to determine when item despawns
        }
    }
}

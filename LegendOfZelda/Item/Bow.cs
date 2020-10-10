using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class Bow : IItem
    {
        private BowSprite bowSprite;
        private SpriteBatch sb;
        public Bow(SpriteBatch spriteBatch)
        {
            bowSprite = (BowSprite)SpriteFactory.Instance.CreateBowSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            bowSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

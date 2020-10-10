using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class Compass : IItem
    {
        private CompassSprite compassSprite;
        private SpriteBatch sb;
        public Compass(SpriteBatch spriteBatch)
        {
            compassSprite = (CompassSprite)SpriteFactory.Instance.CreateCompassSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            compassSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    class Fairy : IItem
    {
        private FairySprite fairySprite;
        private SpriteBatch sb;
        public Fairy(SpriteBatch spriteBatch)
        {
            fairySprite = (FairySprite)SpriteFactory.Instance.CreateFairySprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            fairySprite.Update();
            fairySprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

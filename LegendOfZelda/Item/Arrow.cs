using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    class Arrow : IItem
    {
        private ArrowSprite arrowSprite;
        private SpriteBatch sb;
        public Arrow(SpriteBatch spriteBatch)
        {
            arrowSprite = (ArrowSprite)SpriteFactory.Instance.CreateArrowSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            arrowSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

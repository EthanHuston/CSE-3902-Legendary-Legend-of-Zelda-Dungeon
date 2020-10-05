using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    class Heart : IItem
    {
        private HeartSprite heartSprite;
        private SpriteBatch sb;
        public Heart(SpriteBatch spriteBatch)
        {
            heartSprite = (HeartSprite)SpriteFactory.Instance.CreateHeartSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            heartSprite.Update();
            heartSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

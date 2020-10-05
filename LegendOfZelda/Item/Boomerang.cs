using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    class Boomerang : IItem
    {
        private BoomerangSprite boomerangSprite;
        private SpriteBatch sb;
        public Boomerang(SpriteBatch spriteBatch)
        {
            boomerangSprite = (BoomerangSprite)SpriteFactory.Instance.CreateBoomerangSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            boomerangSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

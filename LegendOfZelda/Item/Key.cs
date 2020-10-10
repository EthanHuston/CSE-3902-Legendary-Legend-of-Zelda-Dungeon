using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class Key : IItem
    {
        private KeySprite keySprite;
        private SpriteBatch sb;
        public Key(SpriteBatch spriteBatch)
        {
            keySprite = (KeySprite)SpriteFactory.Instance.CreateKeySprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            keySprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

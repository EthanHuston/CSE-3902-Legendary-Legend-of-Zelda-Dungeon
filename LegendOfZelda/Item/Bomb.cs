using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    class Bomb : IItem
    {
        private BombSprite bombSprite;
        private SpriteBatch sb;
        public Bomb(SpriteBatch spriteBatch)
        {
            bombSprite = (BombSprite)SpriteFactory.Instance.CreateBombSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            bombSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item
{
    class Map : IItem
    {
        private MapSprite mapSprite;
        private SpriteBatch sb;
        public Map(SpriteBatch spriteBatch)
        {
            mapSprite = (MapSprite)SpriteFactory.Instance.CreateMapSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            mapSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

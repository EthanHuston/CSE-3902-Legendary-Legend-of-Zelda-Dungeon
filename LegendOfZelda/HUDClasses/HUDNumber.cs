using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class HUDNumber
    {
        private ITextureAtlasSprite hudItemsAtlas;
        private Rectangle sourceRectangle;

        public HUDNumber(int num)
        {
            hudItemsAtlas = HUDSpriteFactory.Instance.CreateHUDItemsTextureAtlas();
            AssignNumber(num);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            hudItemsAtlas.Draw(spriteBatch, position, sourceRectangle, layer);
        }

        public void AssignNumber(int num)
        {
            sourceRectangle = new Rectangle(9 * num + 9, 9, 8, 8);
        }
    }
}

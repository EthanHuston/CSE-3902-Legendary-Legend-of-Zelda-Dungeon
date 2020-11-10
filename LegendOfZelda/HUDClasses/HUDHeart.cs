using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class HUDHeart
    {
        private readonly ITextureAtlasSprite hudItemsAtlas;
        private Rectangle sourceRectangle;

        public HUDHeart(int num)
        {
            hudItemsAtlas = HUDSpriteFactory.Instance.CreateHUDItemsTextureAtlas();
            AssignNumber(num);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            hudItemsAtlas.Draw(spriteBatch, position, sourceRectangle);
        }

        public void AssignNumber(int num)
        {
            sourceRectangle = new Rectangle(HUDConstants.EmptyHeartX + 9 * num, HUDConstants.EmptyHeartY, 8, 8);
        }
    }
}

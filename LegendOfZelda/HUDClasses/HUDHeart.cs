using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class HUDHeart
    {
        ITextureAtlasSprite hudItemsAtlas;
        Rectangle sourceRectangle;

        public HUDHeart(int num)
        {
            hudItemsAtlas = HUDSpriteFactory.Instance.CreateHUDItemsTextureAtlas();
            AssignNumber(num);
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            hudItemsAtlas.Draw(spriteBatch, position, sourceRectangle, Constants.DrawLayer.MenuIcon);
        }

        public void AssignNumber(int num)
        {
            sourceRectangle = new Rectangle(HUDConstants.EmptyHeartX + 9 * num, HUDConstants.EmptyHeartY, 8, 8);
        }
    }
}

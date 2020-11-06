using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Pause;
using LegendOfZelda.HUDClasses.Sprite;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class HUDNumber
    {
        ITextureAtlasSprite hudItemsAtlas;
        Rectangle sourceRectangle;

        public HUDNumber(int num)
        {
            hudItemsAtlas = HUDSpriteFactory.Instance.CreateHUDItemsTextureAtlas();
            AssignNumber(num);
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            hudItemsAtlas.Draw(spriteBatch, position, sourceRectangle);
        }

        public void AssignNumber(int num)
        {
            sourceRectangle = new Rectangle(9 * num + 9, 9, 8, 8);
        }
    }
}

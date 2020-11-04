
using LegendOfZelda.GameState.Sprite;
using LegendOfZelda.HUDClasses.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    //Sprite Factory based of model found in slides
    internal class HUDSpriteFactory
    {
        private Texture2D HUDSprite;

        public static HUDSpriteFactory Instance { get; } = new HUDSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            HUDSprite = content.Load<Texture2D>("Menu/HUD");
        }

        public ISprite CreateHUDSprite()
        {
            return new HUDSprite(HUDSprite);
        }
    }
}

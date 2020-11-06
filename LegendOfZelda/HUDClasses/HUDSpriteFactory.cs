
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
        private Texture2D HUDItemsTextureAtlas;
        private Texture2D HUDMiniMap;

        public static HUDSpriteFactory Instance { get; } = new HUDSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            HUDSprite = content.Load<Texture2D>("Menu/HUD");
            HUDItemsTextureAtlas = content.Load<Texture2D>("Menu/HudItems");
            HUDMiniMap = content.Load<Texture2D>("Menu/MiniMap");
        }

        public ISprite CreateHUDSprite()
        {
            return new HUDSprite(HUDSprite);
        }

        public ISprite CreateMiniMapSprite()
        {
            return new MinimapSprite(HUDMiniMap);
        }

        public ITextureAtlasSprite CreateHUDItemsTextureAtlas()
        {
            return new HUDItemsTextureAtlas(HUDItemsTextureAtlas);
        }
    }
}

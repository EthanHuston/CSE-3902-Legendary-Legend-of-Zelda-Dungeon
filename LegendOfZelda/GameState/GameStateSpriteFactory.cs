
using LegendOfZelda.GameState.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState
{
    //Sprite Factory based of model found in slides
    internal class GameStateSpriteFactory
    {
        private Texture2D resumeButtonSprite;
        private Texture2D exitButtonSprite;
        private Texture2D mainMenuButtonSprite;
        private Texture2D inventoryBackgroundSprite;
        private Texture2D mapBackgroundSprite;
        private Texture2D hudItems;

        public static GameStateSpriteFactory Instance { get; } = new GameStateSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            resumeButtonSprite = content.Load<Texture2D>("Menu/ResumeButton");
            exitButtonSprite = content.Load<Texture2D>("Menu/ExitButton");
            mainMenuButtonSprite = content.Load<Texture2D>("Menu/MenuButton");
            inventoryBackgroundSprite = content.Load<Texture2D>("Menu/InventoryBackground");
            mapBackgroundSprite = content.Load<Texture2D>("Menu/MapBackground");
            hudItems = content.Load<Texture2D>("Menu/HudItems");
        }

        public ISprite CreateResumeButtonSprite()
        {
            return new GameStateSprite(resumeButtonSprite);
        }
        public ISprite CreateExitButtonSprite()
        {
            return new GameStateSprite(exitButtonSprite);
        }
        public ISprite CreateMainMenuButtonSprite()
        {
            return new GameStateSprite(mainMenuButtonSprite);
        }
        public ITextureAtlasSprite CreateTitleScreenBackgroundSprite()
        {
            return new GameStateTextureAtlasSprite(titleScreenBackgroundSprite);
        }
        public ISprite CreateInventoryBackgroundSprite()
        {
            return new GameStateSprite(inventoryBackgroundSprite);
        }
        public ISprite CreateMapBackgroundSprite()
        {
            return new GameStateSprite(mapBackgroundSprite);
        }
        public ITextureAtlasSprite CreateHudItemsSprite()
        {
            return new GameStateTextureAtlasSprite(hudItems);
        }
    }
}


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
        private Texture2D titleScreenBackgroundSprite;
        private Texture2D itemSelectionBackground;
        private Texture2D hudItems;

        public static GameStateSpriteFactory Instance { get; } = new GameStateSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            resumeButtonSprite = content.Load<Texture2D>("Menu/ResumeButton");
            exitButtonSprite = content.Load<Texture2D>("Menu/ExitButton");
            mainMenuButtonSprite = content.Load<Texture2D>("Menu/MenuButton");
            titleScreenBackgroundSprite = content.Load<Texture2D>("Menu/TitleScreenBackground");
            itemSelectionBackground = content.Load<Texture2D>("Menu/ItemSelectionBackground");
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
        public ISprite CreateItemSelectionBackgroundSprite()
        {
            return new GameStateSprite(itemSelectionBackground);
        }

        public ITextureAtlasSprite CreateHudItemsSprite()
        {
            return new GameStateTextureAtlasSprite(hudItems);
        }
    }
}

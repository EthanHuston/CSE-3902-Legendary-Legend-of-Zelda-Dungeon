using LegendOfZelda.GameState.Sprite;
using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using LegendOfZelda.Menu.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.GameState
{
    //Sprite Factory based of model found in slides
    internal class GameStateSpriteFactory
    {
        private Texture2D resumeButtonSprite;
        private Texture2D retryButtonBlackSprite;
        private Texture2D exitButtonSprite;
        private Texture2D exitButtonBlackSprite;
        private Texture2D mainMenuButtonSprite;
        private Texture2D titleScreenBackgroundSprite;
        private Texture2D inventoryBackgroundSprite;
        private Texture2D gameOverSprite;
        private Texture2D mapBackgroundSprite;
        private Texture2D hudItems;
        private Texture2D redOverlaySprite;
        private Texture2D blackOverlaySprite;
        private Texture2D buttonSelectorTopLeftSprite;
        private Texture2D buttonSelectorTopRightSprite;
        private Texture2D buttonSelectorBottomRightSprite;
        private Texture2D buttonSelectorBottomLeftSprite;
        private Texture2D acceptButtonSprite;
        private Texture2D onePlayerButtonSprite;
        private Texture2D twoPlayerButtonSprite;
        private Texture2D jojoButtonSprite;
        private Texture2D yakuzaButtonSprite;
        private Texture2D pokemonButtonSprite;
        private Texture2D normalButtonSprite;

        public static GameStateSpriteFactory Instance { get; } = new GameStateSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            resumeButtonSprite = content.Load<Texture2D>("Menu/ResumeButton");
            retryButtonBlackSprite = content.Load<Texture2D>("Menu/RetryButtonBlack");
            exitButtonSprite = content.Load<Texture2D>("Menu/ExitButton");
            exitButtonBlackSprite = content.Load<Texture2D>("Menu/ExitButtonBlack");
            mainMenuButtonSprite = content.Load<Texture2D>("Menu/MenuButton");
            titleScreenBackgroundSprite = content.Load<Texture2D>("Menu/TitleScreenBackground");
            inventoryBackgroundSprite = content.Load<Texture2D>("Menu/InventoryBackground");
            gameOverSprite = content.Load<Texture2D>("Menu/GameOver");
            mapBackgroundSprite = content.Load<Texture2D>("Menu/MapBackground");
            redOverlaySprite = content.Load<Texture2D>("Menu/RedOverlay");
            blackOverlaySprite = content.Load<Texture2D>("Menu/BlackOverlay");
            hudItems = content.Load<Texture2D>("Menu/HudItems");
            buttonSelectorTopLeftSprite = content.Load<Texture2D>("Menu/ButtonSelectorTopLeft");
            buttonSelectorTopRightSprite = content.Load<Texture2D>("Menu/ButtonSelectorTopRight");
            buttonSelectorBottomRightSprite = content.Load<Texture2D>("Menu/ButtonSelectorBottomRight");
            buttonSelectorBottomLeftSprite = content.Load<Texture2D>("Menu/ButtonSelectorBottomLeft");
            acceptButtonSprite = content.Load<Texture2D>("Menu/AcceptButton");
            onePlayerButtonSprite = content.Load<Texture2D>("Menu/OnePlayerButton");
            twoPlayerButtonSprite = content.Load<Texture2D>("Menu/TwoPlayerButton");
            jojoButtonSprite = content.Load<Texture2D>("Menu/JojoButton");
            yakuzaButtonSprite = content.Load<Texture2D>("Menu/YakuzaButton");
            pokemonButtonSprite = content.Load<Texture2D>("Menu/PokemonButton");
            normalButtonSprite = content.Load<Texture2D>("Menu/NormalButton");
        }

        public ISprite CreateResumeButtonSprite()
        {
            return new GameStateSprite(resumeButtonSprite);
        }
        public ISprite CreateRetryButtonBlackSprite()
        {
            return new GameStateSprite(retryButtonBlackSprite);
        }
        public ISprite CreateRedOverlaySprite()
        {
            return new RedOverlaySprite(redOverlaySprite);
        }
        public ISprite CreateBlackOverlaySprite()
        {
            return new BlackOverlaySprite(blackOverlaySprite);
        }
        public ISprite CreateExitButtonBlackSprite()
        {
            return new GameStateSprite(exitButtonBlackSprite);
        }
        public ISprite CreateExitButtonSprite()
        {
            return new GameStateSprite(exitButtonSprite);
        }
        public ISprite CreateMainMenuButtonSprite()
        {
            return new GameStateSprite(mainMenuButtonSprite);
        }
        public ISprite CreateTitleScreenBackgroundSprite()
        {
            return new MainMenuSprite(titleScreenBackgroundSprite);
        }
        public ISprite CreateInventoryBackgroundSprite()
        {
            return new GameStateSprite(inventoryBackgroundSprite);
        }
        public ISprite CreateMapBackgroundSprite()
        {
            return new GameStateSprite(mapBackgroundSprite);
        }
        public ISprite CreateGameOverSprite()
        {
            return new GameStateSprite(gameOverSprite);
        }
        public ITextureAtlasSprite CreateHudItemsSprite()
        {
            return new GameStateTextureAtlasSprite(hudItems);
        }
        public ISprite CreateTopRightButtonSelectorSprite()
        {
            return new TopRightSelectorSprite(buttonSelectorTopRightSprite);
        }
        public ISprite CreateTopLeftButtonSelectorSprite()
        {
            return new TopLeftSelectorSprite(buttonSelectorTopLeftSprite);
        }
        public ISprite CreateBottomRightButtonSelectorSprite()
        {
            return new BottomRightSelectorSprite(buttonSelectorBottomRightSprite);
        }
        public ISprite CreateBottomLeftButtonSelectorSprite()
        {
            return new BottomLeftSelectorSprite(buttonSelectorBottomLeftSprite);
        }
        public ISprite CreateAcceptButtonSprite()
        {
            return new GameStateSprite(acceptButtonSprite);
        }

        public ISprite CreateOnePlayerButtonSprite()
        {
            return new GameStateSprite(onePlayerButtonSprite);
        }
        public ISprite CreateTwoPlayerButtonSprite()
        {
            return new GameStateSprite(twoPlayerButtonSprite);
        }
        public ISprite CreateJojoButtonSprite()
        {
            return new GameStateSprite(jojoButtonSprite);
        }
        public ISprite CreateYakuzaButtonSprite()
        {
            return new GameStateSprite(yakuzaButtonSprite);
        }
        public ISprite CreatePokemonButtonSprite()
        {
            return new GameStateSprite(pokemonButtonSprite);
        }

        internal ISprite CreateNormalButtonSprite()
        {
            return new GameStateSprite(normalButtonSprite);
        }
    }
}

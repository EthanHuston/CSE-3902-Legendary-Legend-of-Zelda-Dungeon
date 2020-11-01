
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

        public static GameStateSpriteFactory Instance { get; } = new GameStateSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Item Sprites
            resumeButtonSprite = content.Load<Texture2D>("Buttons/Resume");
            exitButtonSprite = content.Load<Texture2D>("Buttons/Exit");
        }

        public ISprite CreateResumeButtonSprite()
        {
            return new ButtonSprite(resumeButtonSprite);
        }
        public ISprite CreateExitButtonSprite()
        {
            return new ButtonSprite(exitButtonSprite);
        }
    }
}

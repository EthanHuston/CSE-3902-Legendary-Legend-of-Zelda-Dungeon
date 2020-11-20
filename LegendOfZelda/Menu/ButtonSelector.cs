using LegendOfZelda.GameState;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Menu
{
    class ButtonSelector
    {
        private readonly SpriteBatch spriteBatch;
        private readonly ISprite[] selectorSprites;
        private const int topLeftSelector = 0, topRightSeletor = 1, bottomRightSelector = 2, bottomLeftSelector = 3;
        private const int selectorLength = (int)(3 * Constants.GameScaler);

        public IButton ButtonSelected { get; set; }

        public ButtonSelector(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            selectorSprites = new ISprite[4];
            selectorSprites[topLeftSelector] = GameStateSpriteFactory.Instance.CreateTopLeftButtonSelectorSprite();
            selectorSprites[topRightSeletor] = GameStateSpriteFactory.Instance.CreateTopRightButtonSelectorSprite();
            selectorSprites[bottomRightSelector] = GameStateSpriteFactory.Instance.CreateBottomRightButtonSelectorSprite();
            selectorSprites[bottomLeftSelector] = GameStateSpriteFactory.Instance.CreateBottomLeftButtonSelectorSprite();
        }

        public void Draw()
        {
            if (ButtonSelected == null || !ButtonSelected.IsActive) return;

            Rectangle buttonRectangle = ButtonSelected.GetRectangle();
            int topButtonY = buttonRectangle.Y;
            int bottomButtonY = buttonRectangle.Y + buttonRectangle.Height - selectorLength;
            int leftButtonX = buttonRectangle.X;
            int rightButtonX = buttonRectangle.X + buttonRectangle.Width - selectorLength;

            selectorSprites[topLeftSelector].Draw(spriteBatch,
                new Point(leftButtonX, topButtonY),
                Constants.DrawLayer.MenuButtonSelector);

            selectorSprites[topRightSeletor].Draw(spriteBatch,
                new Point(rightButtonX, topButtonY),
                Constants.DrawLayer.MenuButtonSelector);
            
            selectorSprites[bottomRightSelector].Draw(spriteBatch,
                new Point(rightButtonX, bottomButtonY),
                Constants.DrawLayer.MenuButtonSelector);
            
            selectorSprites[bottomLeftSelector].Draw(spriteBatch,
                new Point(leftButtonX, bottomButtonY),
                Constants.DrawLayer.MenuButtonSelector);
        }

        public void Update()
        {
            foreach (ISprite sprite in selectorSprites) sprite.Update();
        }
    }
}

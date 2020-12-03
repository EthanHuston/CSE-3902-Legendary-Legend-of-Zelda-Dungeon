using System.Collections.Generic;
using LegendOfZelda.GameState;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Menu
{
    class ButtonSelector
    {
        private readonly IMenu owningMenu;
        private readonly SpriteBatch spriteBatch;
        private readonly ISprite[] selectorSprites;
        private readonly int numColumns;
        private readonly List<IButton> buttonsList;
        private const int topLeftSelector = 0, topRightSeletor = 1, bottomRightSelector = 2, bottomLeftSelector = 3;
        private const int selectorLength = (int)(3 * Constants.GameScaler);

        public int SelectedCurrentIndex { get; set; }
        public IButton ButtonSelected { get; set; }

        public ButtonSelector(SpriteBatch spriteBatch, IButtonMenu owningMenu, List<IButton> buttonsList, int numColumns)
        {
            this.owningMenu = owningMenu;
            this.spriteBatch = spriteBatch;

            this.buttonsList = buttonsList;
            this.numColumns = numColumns;

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
            int topButtonY = owningMenu.Position.Y + buttonRectangle.Y;
            int bottomButtonY = owningMenu.Position.Y + buttonRectangle.Y + buttonRectangle.Height - selectorLength;
            int leftButtonX = owningMenu.Position.X + buttonRectangle.X;
            int rightButtonX = owningMenu.Position.X + buttonRectangle.X + buttonRectangle.Width - selectorLength;

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
            ButtonSelected = buttonsList[SelectedCurrentIndex];
        }

        public void MoveSelector(Constants.Direction direction)
        {
            int selectorMoveDistance = GetSelectorMoveDistance(direction);
            int newSelectionIndex = SelectedCurrentIndex;

            do
            {
                newSelectionIndex += selectorMoveDistance;
                if (newSelectionIndex >= buttonsList.Count || newSelectionIndex < 0) return;

            } while (!buttonsList[newSelectionIndex].IsActive);
            SelectedCurrentIndex = newSelectionIndex;
        }

        private int GetSelectorMoveDistance(Constants.Direction direction)
        {
            switch (direction)
            {
                case Constants.Direction.Down:
                    return numColumns;
                case Constants.Direction.Right:
                    return 1;
                case Constants.Direction.Left:
                    return -1;
                case Constants.Direction.Up:
                    return -1 * numColumns;
                default:
                    return 0;
            }
        }
    }
}

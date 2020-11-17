using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.GameWinState
{
    internal class Curtain
    {
        private readonly SpriteBatch spriteBatch;
        private readonly ISprite blackOverlaySpriteLeft;
        private readonly ISprite blackOverlaySpriteRight;
        private Point leftPos;
        private Point rightPos;

        public Curtain(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            blackOverlaySpriteLeft = GameStateSpriteFactory.Instance.CreateBlackOverlaySprite();
            blackOverlaySpriteRight = GameStateSpriteFactory.Instance.CreateBlackOverlaySprite();
            leftPos = GameStateConstants.WinStateSpriteLocationLeft;
            rightPos = GameStateConstants.WinStateSpriteLocationRight;
        }

        public void Draw()
        {
            blackOverlaySpriteLeft.Draw(spriteBatch, leftPos, Constants.DrawLayer.BlackLayer);
            blackOverlaySpriteRight.Draw(spriteBatch, rightPos, Constants.DrawLayer.BlackLayer);
        }

        public void Update()
        {
            if (leftPos.X <= 0 && rightPos.X >= Constants.MaxXPos / 2)
            {
                leftPos.X += 10;
                rightPos.X -= 10;
            }
        }
    }
}

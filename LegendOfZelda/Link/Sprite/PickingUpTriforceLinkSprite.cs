﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Sprite
{
    class PickingUpTriforceLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int currentFrame;
        private int bufferFrame;
        private const int totalFrames = 16;
        private const int numRows = 1;
        private const int numColumns = 2;

        public PickingUpTriforceLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames + Constants.LinkPickingUpItemPauseTicks;
            if (FinishedAnimation()) return;

            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            if (++damageColorCounter == Constants.LinkDamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage)
        {
            if (FinishedAnimation()) return;

            int frameWidth = sprite.Width / numRows;
            int frameHeight = sprite.Height / numColumns;
            int currentRow = 1;
            int currentColumn = currentFrame % 2;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(frameWidth * Constants.SpriteScaler), (int)(frameHeight * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.White : Color.Red);
            spriteBatch.End();
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }
    }
}

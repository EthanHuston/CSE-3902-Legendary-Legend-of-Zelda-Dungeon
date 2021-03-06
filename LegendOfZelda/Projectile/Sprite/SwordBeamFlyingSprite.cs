﻿using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    internal class SwordBeamFlyingSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private readonly int totalFrames;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private const int numRows = 1;
        private const int numColumns = 4;
        private const int frameDelay = 10;
        private readonly bool pokemonOn;

        public SwordBeamFlyingSprite(Texture2D sprite, bool pokemonOn)
        {
            this.sprite = sprite;
            bufferFrame = 0;
            currentFrame = 0;
            totalFrames = numColumns * numRows;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
            this.pokemonOn = pokemonOn;
        }

        public void Update()
        {
            if (++bufferFrame == frameDelay)
            {
                currentFrame = currentFrame == totalFrames - 1 ? 0 : currentFrame + 1;
                bufferFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            int currentRow = 0;
            int currentColumn = currentFrame;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
            if (pokemonOn)
            {
                destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.TrainerScaler), (int)(frameHeight * Constants.TrainerScaler));
            }

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public bool FinishedAnimation()
        {
            return false; // not used, BoomerangFlying class keeps track of this
        }

        public Rectangle GetPositionRectangle()
        {
            Rectangle returning = new Rectangle(0, 0, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
            if (pokemonOn)
            {
                returning = new Rectangle(0, 0, (int)(frameWidth * Constants.TrainerScaler), (int)(frameHeight * Constants.TrainerScaler));
            }
            return returning;
        }
    }
}

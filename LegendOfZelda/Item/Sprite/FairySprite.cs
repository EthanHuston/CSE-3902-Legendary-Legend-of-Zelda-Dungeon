using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Item.Sprite
{
    internal class FairySprite : ISprite
    {
        private const int numRows = 1;
        private const int numColumns = 2;
        private readonly Texture2D sprite;
        private readonly int totalFrames;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private int currentFrame;
        private int bufferFrame;
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;

        private Point position;
        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public FairySprite(Texture2D sprite, Point spawnPosition)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;

            position = spawnPosition;
        }
        public void Update()
        {
            movementBuffer++;
            CheckBounds();
            //Move based on current chosen direction for some time.
            if (xDir == 0 && yDir == 0)
            {
                position.X--;
                position.Y--;
            }
            else if (xDir == 0 && yDir == 1)
            {
                position.X--;
                position.Y++;
            }
            else if (xDir == 1 && yDir == 0)
            {
                position.X++;
                position.Y--;
            }
            else
            {
                position.X++;
                position.Y++;
            }

            if (movementBuffer > 10)
            {
                movementBuffer = 0;
                ChooseDirection();
            }
            bufferFrame++;
            if (bufferFrame == 6)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            int row = (int)(currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * sprite.Width / 1.5), (int)(Constants.GameScaler * sprite.Height / 1.5));

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }
        private void CheckBounds()
        {
            if (position.X < RoomConstants.BackgroundX)
            {
                position.X += 5;
            }
            else if (position.X > RoomConstants.RightDoorX)
            {
                position.X -= 5; ;
            }
            else if (position.Y < RoomConstants.RoomBorderY)
            {
                position.Y += 5; ;
            }
            else if (position.Y > RoomConstants.BottomDoorY)
            {
                position.Y -= 5;
            }
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
        }
    }
}

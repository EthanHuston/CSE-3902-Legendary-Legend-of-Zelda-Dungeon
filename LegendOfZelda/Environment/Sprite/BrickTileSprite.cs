﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    class BrickTileSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public BrickTileSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = Rectangle.Empty;
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            destinationRectangle = new Rectangle(position.X, position.Y, (int) (RoomConstants.SpriteMultiplier * sprite.Width), (int) (RoomConstants.SpriteMultiplier * sprite.Height));
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

    }
}

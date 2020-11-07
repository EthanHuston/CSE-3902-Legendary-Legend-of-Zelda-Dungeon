﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.HUDClasses.Sprite
{
    class HUDItemsTextureAtlas : ITextureAtlasSprite
    {
        private Texture2D sprite;

        public HUDItemsTextureAtlas(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Rectangle textureSource)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(textureSource.Width * Constants.GameScaler), (int)(textureSource.Height * Constants.GameScaler));
            spriteBatch.Draw(sprite, destinationRectangle, textureSource, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation)
        {
            //Not needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            //Not needed
        }

        public Rectangle GetPositionRectangle()
        {
            return Rectangle.Empty;
        }

        public void Update()
        {
            //No update needed
        }
    }
}
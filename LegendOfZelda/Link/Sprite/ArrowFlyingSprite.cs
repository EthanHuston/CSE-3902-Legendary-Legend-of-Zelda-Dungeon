﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Sprite
{
    class ArrowFlyingSprite : ILinkItemSprite
    {
        private Texture2D sprite;
        public ArrowFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }

        public void Update()
        {
            // All updating is done in the class for this entity
        }

        public bool FinishedAnimation()
        {
            return false; // not used
        }
    }
}
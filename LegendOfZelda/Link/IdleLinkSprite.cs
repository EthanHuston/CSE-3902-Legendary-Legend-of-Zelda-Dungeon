﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Link.Sprite
{
    class IdleLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        public IdleLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            // TODO: Double check this, but I don't think we need to do anything here?
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(Constants.Sprint2LinkSpawnX, Constants.Sprint2LinkSpawnY), Color.White);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class JellySprite : ISprite
    {
        private Texture2D sprite;
        public JellySprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {

        }
    }
}
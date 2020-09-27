using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class IdleDamagedLinkSprite : ISprite
    {
        private Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 2;
        private const int frameDelay = 5;
        private Color currentColor;
        public IdleDamagedLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == frameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            currentColor = currentFrame == 0 ? Color.White : Color.Red;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(Constants.Sprint2LinkSpawnX, Constants.Sprint2LinkSpawnY), currentColor);
        }
    }
}

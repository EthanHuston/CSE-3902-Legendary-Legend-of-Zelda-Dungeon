using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprite
{
    class IdleDamagedLinkSprite : ISprite
    {
        private Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 2;
        private const int frameDelay = 5;
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
            currentFrame = currentFrame == totalFrames ? 0 : currentFrame;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(Constants.Sprint2LinkSpawnX, Constants.Sprint2LinkSpawnY), currentFrame == 0 ? Color.White : Color.Red);
        }
    }
}

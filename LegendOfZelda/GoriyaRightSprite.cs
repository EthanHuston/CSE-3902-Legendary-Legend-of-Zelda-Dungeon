using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class GoriyaRightSprite : ISprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;

        public GoriyaRightSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 4;
            Columns = 2;
            currentFrame = 0;
            bufferFrame = 6;
            totalFrames = Columns;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {

        }

    }
}

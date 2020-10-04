using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class GoriyaDownSprite : ISprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;

        public GoriyaDownSprite(Texture2D sprite)
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
            bufferFrame++;
            if(bufferFrame == 6)
            {
                
            }
        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {

        }

    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class DoorSprite : ISprite
    {
        private Texture2D sprite;
        public DoorSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {
            
        }

        public void Update()
        {
            
        }
    }
}

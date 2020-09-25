using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class BlockSprite : ISprite
    {
        private Texture2D sprite;
        public BlockSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}

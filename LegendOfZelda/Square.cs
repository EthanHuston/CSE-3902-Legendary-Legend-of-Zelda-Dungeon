using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Square : IInteractiveEnviornment
    {
        private BlockSprite blockSprite;
        private SpriteBatch sB;
        public Square(SpriteBatch spriteBatch)
        {
            blockSprite = (BlockSprite)SpriteFactory.Instance.CreateBlockSprite();
            sB = spriteBatch;
            blockSprite.Draw(sB, Sprint2.itemX, Sprint2.itemY);
        }

        public void Interation()
        {
            
        }
    }
}

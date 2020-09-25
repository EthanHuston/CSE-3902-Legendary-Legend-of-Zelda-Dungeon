using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Fire : IInteractiveEnviornment
    {
        private FireSprite fireSprite;
        private SpriteBatch sB;
        public Fire(SpriteBatch spriteBatch)
        {
            fireSprite = (FireSprite)SpriteFactory.Instance.CreateFireSprite();
            sB = spriteBatch;
            fireSprite.Draw(sB, Sprint2.itemX, Sprint2.itemY);
        }

        public void Interation()
        {
            //Update
        }

    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Merchant : INPC
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        public Merchant(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateMerchantSprite();
            this.spriteBatch = spriteBatch;

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, Sprint2.enemyNPCX, Sprint2.enemyNPCY);
        }

        public void Update()
        {
        }
    }
}

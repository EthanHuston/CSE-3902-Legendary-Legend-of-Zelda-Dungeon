using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Key : IItem
    {
        private int itemIndex = 2;
        private KeySprite keySprite;
        private SpriteBatch sb;
        public Key(SpriteBatch spriteBatch)
        {
            keySprite = (KeySprite)SpriteFactory.Instance.CreateKeySprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                keySprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

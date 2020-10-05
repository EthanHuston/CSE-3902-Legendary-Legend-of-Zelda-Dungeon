using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Key : IItem
    {
        private KeySprite keySprite;
        private SpriteBatch sb;
        public Key(SpriteBatch spriteBatch)
        {
            keySprite = (KeySprite)SpriteFactory.Instance.CreateKeySprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            keySprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

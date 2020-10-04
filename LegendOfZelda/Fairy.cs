using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Fairy : IItem
    {
        private int itemIndex = 11;
        private FairySprite fairySprite;
        private SpriteBatch sb;
        public Fairy(SpriteBatch spriteBatch)
        {
            fairySprite = (FairySprite)SpriteFactory.Instance.CreateFairySprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                fairySprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

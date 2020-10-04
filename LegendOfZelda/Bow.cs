using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Bow : IItem
    {
        private int itemIndex = 6;
        private BowSprite bowSprite;
        private SpriteBatch sb;
        public Bow(SpriteBatch spriteBatch)
        {
            bowSprite = (BowSprite)SpriteFactory.Instance.CreateBowSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                bowSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

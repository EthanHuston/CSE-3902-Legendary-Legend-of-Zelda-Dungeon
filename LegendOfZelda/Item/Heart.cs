using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Heart : IItem
    {
        private int itemIndex = 7;
        private HeartSprite heartSprite;
        private SpriteBatch sb;
        public Heart(SpriteBatch spriteBatch)
        {
            heartSprite = (HeartSprite)SpriteFactory.Instance.CreateHeartSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                heartSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

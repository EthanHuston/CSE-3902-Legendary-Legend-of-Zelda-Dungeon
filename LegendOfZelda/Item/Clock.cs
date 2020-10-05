using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Clock : IItem
    {
        private ClockSprite clockSprite;
        private SpriteBatch sb;
        public Clock(SpriteBatch spriteBatch)
        {
            clockSprite = (ClockSprite)SpriteFactory.Instance.CreateClockSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                clockSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

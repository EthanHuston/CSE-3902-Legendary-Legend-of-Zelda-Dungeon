using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Compass : IItem
    {
        private int itemIndex = 0;
        private CompassSprite compassSprite;
        private SpriteBatch sb;
        public Compass(SpriteBatch spriteBatch)
        {
            compassSprite = (CompassSprite)SpriteFactory.Instance.CreateCompassSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                compassSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

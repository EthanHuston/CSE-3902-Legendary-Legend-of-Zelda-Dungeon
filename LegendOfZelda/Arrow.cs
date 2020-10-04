using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Arrow : IItem
    {
        private int itemIndex = 9;
        private ArrowSprite arrowSprite;
        private SpriteBatch sb;
        public Arrow(SpriteBatch spriteBatch)
        {
            arrowSprite = (ArrowSprite)SpriteFactory.Instance.CreateArrowSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                arrowSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

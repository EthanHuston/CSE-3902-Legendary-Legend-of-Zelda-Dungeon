using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Arrow : IItem
    {
        private ArrowSprite arrowSprite;
        private SpriteBatch sb;
        public Arrow(SpriteBatch spriteBatch)
        {
            arrowSprite = (ArrowSprite)SpriteFactory.Instance.CreateArrowSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            arrowSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

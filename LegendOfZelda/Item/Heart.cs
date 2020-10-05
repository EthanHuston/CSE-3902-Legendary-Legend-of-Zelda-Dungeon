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
        private HeartSprite heartSprite;
        private SpriteBatch sb;
        public Heart(SpriteBatch spriteBatch)
        {
            heartSprite = (HeartSprite)SpriteFactory.Instance.CreateHeartSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            heartSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

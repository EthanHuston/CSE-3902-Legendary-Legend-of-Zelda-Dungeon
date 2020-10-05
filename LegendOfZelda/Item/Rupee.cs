using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Rupee : IItem
    {
        private RupeeSprite rupeeSprite;
        private SpriteBatch sb;
        public Rupee(SpriteBatch spriteBatch)
        {
            rupeeSprite = (RupeeSprite)SpriteFactory.Instance.CreateRupeeSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                rupeeSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

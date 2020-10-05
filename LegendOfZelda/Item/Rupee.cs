using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LegendOfZelda.Sprint2;
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
            rupeeSprite.Update();
            rupeeSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.Sprint2;

namespace LegendOfZelda.Item
{
    class Bow : IItem
    {
        private BowSprite bowSprite;
        private SpriteBatch sb;
        public Bow(SpriteBatch spriteBatch)
        {
            bowSprite = (BowSprite)SpriteFactory.Instance.CreateBowSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            bowSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

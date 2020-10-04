using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Triforce : IItem
    {
        private int itemIndex = 4;
        private TriforceSprite triforceSprite;
        private SpriteBatch sb;
        public Triforce(SpriteBatch spriteBatch)
        {
            triforceSprite = (TriforceSprite)SpriteFactory.Instance.CreateTriforceSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                triforceSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

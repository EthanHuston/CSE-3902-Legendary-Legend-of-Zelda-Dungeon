using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Boomerang : IItem
    {
        private int itemIndex = 5;
        private BoomerangSprite boomerangSprite;
        private SpriteBatch sb;
        public Boomerang(SpriteBatch spriteBatch)
        {
            boomerangSprite = (BoomerangSprite)SpriteFactory.Instance.CreateBoomerangSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                boomerangSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

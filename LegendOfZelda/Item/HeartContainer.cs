using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class HeartContainer : IItem
    {
        private HeartContainerSprite heartContainerSprite;
        private SpriteBatch sb;
        public HeartContainer(SpriteBatch spriteBatch)
        {
            heartContainerSprite = (HeartContainerSprite)SpriteFactory.Instance.CreateHeartContainerSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                heartContainerSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

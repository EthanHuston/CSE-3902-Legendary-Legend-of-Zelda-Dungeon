using LegendOfZelda.Sprint2;
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
            heartContainerSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

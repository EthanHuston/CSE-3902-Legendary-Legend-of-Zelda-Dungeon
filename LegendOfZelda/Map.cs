using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Map : IItem
    {
        private int itemIndex = 1;
        private CompassSprite compassSprite;
        private SpriteBatch sb;
        public Map(SpriteBatch spriteBatch)
        {
            compassSprite = (CompassSprite)SpriteFactory.Instance.CreateMapSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                compassSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

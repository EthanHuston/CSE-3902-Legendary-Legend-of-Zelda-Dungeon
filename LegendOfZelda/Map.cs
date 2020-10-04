using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Map : IItem
    {
        private int itemIndex = 1;
        private MapSprite mapSprite;
        private SpriteBatch sb;
        public Map(SpriteBatch spriteBatch)
        {
            mapSprite = (MapSprite)SpriteFactory.Instance.CreateMapSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                mapSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

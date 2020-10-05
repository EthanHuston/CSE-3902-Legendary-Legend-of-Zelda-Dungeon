using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using LegendOfZelda.Sprint2;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Map : IItem
    {
        private MapSprite mapSprite;
        private SpriteBatch sb;
        public Map(SpriteBatch spriteBatch)
        {
            mapSprite = (MapSprite)SpriteFactory.Instance.CreateMapSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            mapSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

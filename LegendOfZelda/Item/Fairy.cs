using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Fairy : IItem
    {
        private FairySprite fairySprite;
        private SpriteBatch sb;
        public Fairy(SpriteBatch spriteBatch)
        {
            fairySprite = (FairySprite)SpriteFactory.Instance.CreateFairySprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            fairySprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

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
        private BoomerangSprite boomerangSprite;
        private SpriteBatch sb;
        public Boomerang(SpriteBatch spriteBatch)
        {
            boomerangSprite = (BoomerangSprite)SpriteFactory.Instance.CreateBoomerangSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            boomerangSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

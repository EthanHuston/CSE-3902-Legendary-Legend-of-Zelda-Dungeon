using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Item
{
    class Triforce : IItem
    {
        private TriforceSprite triforceSprite;
        private SpriteBatch sb;
        public Triforce(SpriteBatch spriteBatch)
        {
            triforceSprite = (TriforceSprite)SpriteFactory.Instance.CreateTriforceSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            triforceSprite.Update();
            triforceSprite.Draw(sb, ConstantsSprint2.itemX, ConstantsSprint2.itemY);
        }
    }
}

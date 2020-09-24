using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Compass : IItem
    {
        private int itemIndex = 0; // For the itemList action in Sprint2.
        private CompassSprite compassSprite;
        public Compass()
        {
            compassSprite = (CompassSprite)SpriteFactory.Instance.CreateCompassSprite();
        }

        public void itemAction()
        {
            compassSprite.Draw(new SpriteBatch);
        }
    }
}

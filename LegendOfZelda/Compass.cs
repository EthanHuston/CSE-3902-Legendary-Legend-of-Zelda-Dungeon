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
        private int itemIndex = 0;
        private CompassSprite compassSprite;
        private SpriteBatch sb;
        public Compass(SpriteBatch spriteBatch)
        {
            compassSprite = (CompassSprite)SpriteFactory.Instance.CreateCompassSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            compassSprite.Draw(sb);
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Bomb : IItem
    {
        private int itemIndex = 10;
        private BombSprite bombSprite;
        private SpriteBatch sb;
        public Bomb(SpriteBatch spriteBatch)
        {
            bombSprite = (BombSprite)SpriteFactory.Instance.CreateBombSprite();
            sb = spriteBatch;
        }

        public void itemAction()
        {
            if (Sprint2.itemListCount == itemIndex)
            {
                bombSprite.Draw(sb, Sprint2.itemX, Sprint2.itemY);
            }
        }
    }
}

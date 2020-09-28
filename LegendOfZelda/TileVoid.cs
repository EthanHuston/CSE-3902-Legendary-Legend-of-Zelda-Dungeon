using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class TileVoid : INonInteractiveEnvironment
    {
        private TileVoidSprite sprite;
        private SpriteBatch sb;
        private int posX, posY;
        bool canWalk;

        public TileVoid(SpriteBatch spriteBatch, int x, int y)
        {
            sprite = (TileVoidSprite)SpriteFactory.Instance.CreateTileVoidSprite();
            sb = spriteBatch;
            posX = x;
            posY = y;
            canWalk = false;
        }

        public void Draw()
        {
            sprite.Draw(sb, posX, posY);
        }

        public int getX()
        {
            return posX;
        }

        public int getY()
        {
            return posY;
        }
    }
}

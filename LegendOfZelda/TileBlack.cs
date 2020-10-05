using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class TileBlack : INonInteractiveEnvironment
    {
        private TileBlackSprite sprite;
        private SpriteBatch sb;
        private int posX, posY;
        bool canWalk;

        public TileBlack(SpriteBatch spriteBatch, int x, int y)
        {
            sprite = (TileBlackSprite)SpriteFactory.Instance.CreateTileBlackSprite();
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

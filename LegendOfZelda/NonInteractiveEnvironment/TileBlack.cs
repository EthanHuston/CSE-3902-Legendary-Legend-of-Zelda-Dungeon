using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.NonInteractiveEnvironment
{
    class TileBlack : IBlock
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
        public void Update()
        {
        }
    }
}

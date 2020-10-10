using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.NonInteractiveEnvironment
{
    class TileWater : IBlock
    {
        private TileWaterSprite sprite;
        private SpriteBatch sb;
        private int posX, posY;
        bool canWalk;

        public TileWater(SpriteBatch spriteBatch, int x, int y)
        {
            sprite = (TileWaterSprite)SpriteFactory.Instance.CreateTileWaterSprite();
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

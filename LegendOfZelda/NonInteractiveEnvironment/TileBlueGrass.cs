using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.NonInteractiveEnvironment
{
    class TileBlueGrass : IBlock
    {
        private TileBlueGrassSprite sprite;
        private SpriteBatch sb;
        private int posX, posY;
        bool canWalk;

        public TileBlueGrass(SpriteBatch spriteBatch, int x, int y)
        {
            sprite = (TileBlueGrassSprite)SpriteFactory.Instance.CreateTileBlueGrassSprite();
            sb = spriteBatch;
            posX = x;
            posY = y;
            canWalk = true;
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

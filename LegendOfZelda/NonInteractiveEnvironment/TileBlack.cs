using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class TileBlack : IBlock
    {
        private TileBlackSprite sprite;
        private SpriteBatch sb;
        private Point position;
        bool canWalk;

        public TileBlack(SpriteBatch spriteBatch, Point position)
        {
            sprite = (TileBlackSprite)SpriteFactory.Instance.CreateTileBlackSprite();
            sb = spriteBatch;
            this.position = position;
            canWalk = false;
        }

        public void Draw()
        {
            sprite.Draw(sb, position);
        }

        public int getX()
        {
            return position.X;
        }

        public int getY()
        {
            return position.Y;
        }
        public void Update()
        {
        }
    }
}

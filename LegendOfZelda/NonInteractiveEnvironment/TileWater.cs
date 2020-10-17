using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class TileWater : IBlock
    {
        private TileWaterSprite sprite;
        private SpriteBatch sb;
        private Point position;
        bool canWalk;

        public TileWater(SpriteBatch spriteBatch, Point position)
        {
            sprite = (TileWaterSprite)SpriteFactory.Instance.CreateTileWaterSprite();
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

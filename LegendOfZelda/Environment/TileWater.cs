using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class TileWater : IBlock
    {
        private ISprite sprite;
        private SpriteBatch sb;
        private Point position;
        bool canWalk;

        public TileWater(SpriteBatch spriteBatch, Point position)
        {
            sprite = EnvironmentSpriteFactory.Instance.CreateTileWaterSprite();
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

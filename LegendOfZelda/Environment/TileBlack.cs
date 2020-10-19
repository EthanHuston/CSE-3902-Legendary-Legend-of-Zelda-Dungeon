using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class TileBlack : IBlock
    {
        private ISprite sprite;
        private SpriteBatch sb;
        private Point position;
        bool canWalk;

        public TileBlack(SpriteBatch spriteBatch, Point position)
        {
            sprite = EnvironmentSpriteFactory.Instance.CreateTileBlackSprite();
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
            sprite.Update();
        }
    }
}

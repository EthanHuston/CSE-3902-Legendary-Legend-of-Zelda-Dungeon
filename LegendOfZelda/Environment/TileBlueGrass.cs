using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class TileBlueGrass : IBlock
    {
        private ISprite sprite;
        private SpriteBatch sb;
        private Point position;
        bool canWalk;

        public TileBlueGrass(SpriteBatch spriteBatch, Point position)
        {
            sprite = EnvironmentSpriteFactory.Instance.CreateTileBlueGrassSprite();
            sb = spriteBatch;
            this.position = position;
            canWalk = true;
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

using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class TileBlueGrass : IBlock
    {
        private TileBlueGrassSprite sprite;
        private SpriteBatch sb;
        private Point position;
        bool canWalk;

        public TileBlueGrass(SpriteBatch spriteBatch, Point position)
        {
            sprite = (TileBlueGrassSprite)SpriteFactory.Instance.CreateTileBlueGrassSprite();
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

using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
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

        public void Despawn()
        {
            throw new System.NotImplementedException();
        }

        public void Draw()
        {
            sprite.Draw(sb, position);
        }

        public Point GetPosition()
        {
            throw new System.NotImplementedException();
        }

        public Rectangle GetRectangle()
        {
            throw new System.NotImplementedException();
        }

        public int getX()
        {
            return position.X;
        }

        public int getY()
        {
            return position.Y;
        }

        public void Move(Vector2 distance)
        {
            throw new System.NotImplementedException();
        }

        public bool SafeToDespawn()
        {
            throw new System.NotImplementedException();
        }

        public void SetPosition(Point position)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
        }

    }
}

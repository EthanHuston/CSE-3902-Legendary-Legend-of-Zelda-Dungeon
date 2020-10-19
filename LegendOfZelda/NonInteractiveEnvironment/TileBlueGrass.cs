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
        private bool safeToDespawn;
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
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(sb, position);
        }

        public Point GetPosition()
        {
            return position;
        }

        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public void Move(Vector2 distance)
        {
            throw new System.NotImplementedException();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void SetPosition(Point position)
        {
            this.position = position;
        }

        public void Update()
        {
        }

    }
}

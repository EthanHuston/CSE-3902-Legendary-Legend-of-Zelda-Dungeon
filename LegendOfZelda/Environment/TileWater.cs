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
        private bool safeToDespawn;
        bool canWalk;

        public TileWater(SpriteBatch spriteBatch, Point position)
        {
            sprite = EnvironmentSpriteFactory.Instance.CreateTileWaterSprite();
            sb = spriteBatch;
            this.position = position;
            safeToDespawn = false;
            canWalk = false;
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
            return position);
        }

        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public void Move(Vector2 distance)
        {
            position.X = (int)distance.X;
            position.Y = (int)distance.Y;
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

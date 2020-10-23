using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Square : IBlock
    {
        private ISprite blockSprite;
        private SpriteBatch spriteBatch;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Square(SpriteBatch spriteBatch, Point spawnPosition)
        {
            blockSprite = EnvironmentSpriteFactory.Instance.CreateBlockSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            blockSprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            blockSprite.Update();
        }

        public Rectangle GetRectangle()
        {
            return blockSprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
        void Move(int distance, Vector2 velocity) {
            // do something
        }
    }
}

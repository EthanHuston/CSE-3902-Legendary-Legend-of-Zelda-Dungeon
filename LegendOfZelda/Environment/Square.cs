using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class Square : IBlock
    {
        private readonly ISprite blockSprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Square(SpriteBatch spriteBatch, Point spawnPosition)
        {
            blockSprite = EnvironmentSpriteFactory.Instance.CreateSquareSprite();
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            blockSprite.Draw(spriteBatch, position, Constants.DrawLayer.Block);
        }

        public void Update()
        {
            blockSprite.Update();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, blockSprite.GetPositionRectangle().Width, blockSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}

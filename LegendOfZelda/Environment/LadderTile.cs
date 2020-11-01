using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class LadderTile : IBlock
    {
        private readonly ISprite ladderSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public LadderTile(SpriteBatch spriteBatch, Point position)
        {
            ladderSprite = EnvironmentSpriteFactory.Instance.CreateLadderSprite();
            sB = spriteBatch;
            Position = position;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            ladderSprite.Draw(sB, Position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, ladderSprite.GetPositionRectangle().Width, ladderSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // condition here to despawn
        }
    }
}

using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class LadderTile : IBlock
    {
        private ISprite ladderSprite;
        private SpriteBatch sB;
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
            return ladderSprite.GetPositionRectangle();
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

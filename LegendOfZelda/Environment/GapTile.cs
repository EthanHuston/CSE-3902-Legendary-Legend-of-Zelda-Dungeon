using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class GapTile : IBlock
    {
        private ISprite tileBlackSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public GapTile(SpriteBatch spriteBatch, Point spawnPosition)
        {
            tileBlackSprite = EnvironmentSpriteFactory.Instance.CreateTileBlackSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            tileBlackSprite.Draw(sB, Position);
        }

        public Rectangle GetRectangle()
        {
            return tileBlackSprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // some condition here if we want to despawn
        }

    }
}

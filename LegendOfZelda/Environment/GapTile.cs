using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class GapTile : IBlock
    {
        private readonly ISprite tileBlackSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public GapTile(SpriteBatch spriteBatch, Point spawnPosition)
        {
            tileBlackSprite = EnvironmentSpriteFactory.Instance.CreateTileBlackSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            SafeToDespawn = false;
        }

        public void Despawn()
        {
            SafeToDespawn = true;
        }

        public void Draw()
        {
            tileBlackSprite.Draw(sB, Position, Constants.DrawLayer.FloorTile);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, tileBlackSprite.GetPositionRectangle().Width, tileBlackSprite.GetPositionRectangle().Height);
        }

        

        public void Update()
        {
            SafeToDespawn = SafeToDespawn || false; // some condition here if we want to despawn
        }

    }
}

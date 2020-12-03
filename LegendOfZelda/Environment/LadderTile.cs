using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class LadderTile : IBackground
    {
        private readonly ISprite ladderSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public LadderTile(SpriteBatch spriteBatch, Point position)
        {
            ladderSprite = EnvironmentSpriteFactory.Instance.CreateLadderSprite();
            sB = spriteBatch;
            Position = position;
            SafeToDespawn = false;
        }

        public void Despawn()
        {
            SafeToDespawn = true;
        }

        public void Draw()
        {
            ladderSprite.Draw(sB, Position, Constants.DrawLayer.FloorTile);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, ladderSprite.GetPositionRectangle().Width, ladderSprite.GetPositionRectangle().Height);
        }

        

        public void Update()
        {
            SafeToDespawn = SafeToDespawn || false; // condition here to despawn
        }
    }
}

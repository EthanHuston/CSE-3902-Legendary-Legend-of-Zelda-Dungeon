using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class TileBlack : IBlock
    {
        private readonly ISprite sprite;
        private readonly SpriteBatch sb;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public TileBlack(SpriteBatch spriteBatch, Point position)
        {
            sprite = EnvironmentSpriteFactory.Instance.CreateTileBlackSprite();
            sb = spriteBatch;
            Position = position;
            SafeToDespawn = false;
        }
        
        public void Draw()
        {
            sprite.Draw(sb, position, Constants.DrawLayer.FloorTile);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }
        
        public void Update()
        {
            sprite.Update();
        }
    }
}

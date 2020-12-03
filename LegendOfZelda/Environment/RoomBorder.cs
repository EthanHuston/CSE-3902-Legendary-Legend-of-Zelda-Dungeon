using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class RoomBorder : IBackground
    {
        private readonly ISprite roomSprite;
        private readonly SpriteBatch sb;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public RoomBorder(SpriteBatch spriteBatch, Point spawnPosition)
        {
            roomSprite = EnvironmentSpriteFactory.Instance.CreateRoomBorderSprite();
            sb = spriteBatch;
            Position = spawnPosition;
            SafeToDespawn = false;
        }
        
        public void Draw()
        {
            roomSprite.Draw(sb, position, Constants.DrawLayer.Border);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, roomSprite.GetPositionRectangle().Width, roomSprite.GetPositionRectangle().Height);
        }
        
        public void Update()
        {
            SafeToDespawn = SafeToDespawn || false; // condition to despawn
            roomSprite.Update();
        }
    }
}

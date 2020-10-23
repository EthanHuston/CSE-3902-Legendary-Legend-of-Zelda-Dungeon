using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class RoomBorder : IBlock
    {
        private ISprite roomSprite;
        private SpriteBatch sb;
        private Rectangle destinationRectangle;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public RoomBorder(SpriteBatch spriteBatch, Point spawnPosition)
        {
            roomSprite = EnvironmentSpriteFactory.Instance.CreateRoomBorderSprite();
            sb = spriteBatch;
            Position = spawnPosition;
            destinationRectangle = Rectangle.Empty;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            roomSprite.Draw(sb, position);
        }

        public Rectangle GetRectangle()
        {
            return destinationRectangle;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // condition to despawn
            roomSprite.Update();
        }
    }
}

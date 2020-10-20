using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class RoomBorder : IBlock
    {
        private ISprite roomSprite;
        private SpriteBatch sb;
        private Point position;
        private Rectangle destinationRectangle;
        private bool safeToDespawn;

        public RoomBorder(SpriteBatch spriteBatch, Point spawnPosition)
        {
            roomSprite = EnvironmentSpriteFactory.Instance.CreateRoomBorderSprite();
            sb = spriteBatch;
            position = spawnPosition;
            destinationRectangle = Rectangle.Empty;
            safeToDespawn = false;
        }

        public void Draw()
        {
            roomSprite.Draw(sb, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return destinationRectangle;
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void SetPosition(Point position)
        {
            this.position = new Point(position.X, position.Y);
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // condition to despawn
            roomSprite.Update();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}

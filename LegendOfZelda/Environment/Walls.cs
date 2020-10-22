using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Walls : IBlock
    {
        private ISprite roomBorderSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Walls(SpriteBatch spriteBatch, Point spawnPosition)
        {
            roomBorderSprite = EnvironmentSpriteFactory.Instance.CreateRoomBorderSprite();
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
            roomBorderSprite.Draw(sB, Position);
        }

        public Rectangle GetRectangle()
        {
            return roomBorderSprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            roomBorderSprite.Update();
        }
    }
}

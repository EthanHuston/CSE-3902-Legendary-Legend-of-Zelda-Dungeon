using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Button
{
    class EmptyButton : IButton
    {
        private bool safeToDespawn;
        private Rectangle location;
        public bool IsActive { get; private set; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public EmptyButton(Rectangle location)
        {
            Position = new Point(location.X, location.Y);
            safeToDespawn = false;
            IsActive = true;
            this.location = location;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
        }

        public Rectangle GetRectangle()
        {
            return !IsActive ?
                Rectangle.Empty :
                new Rectangle(Position.X, Position.Y, location.Width, location.Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
        }

        public void MakeActive()
        {
            IsActive = true;
        }

        public void MakeInactive()
        {
            IsActive = false;
        }
    }
}

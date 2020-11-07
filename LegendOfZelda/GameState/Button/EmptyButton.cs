using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Button
{
    class EmptyButton : IButton
    {
        private bool safeToDespawn;
        private Rectangle size;
        private readonly IMenu owningMenu;

        public bool IsActive { get; private set; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public EmptyButton(IMenu owner, Rectangle location)
        {
            owningMenu = owner;
            Position = new Point(location.X, location.Y);
            safeToDespawn = false;
            IsActive = true;
            size = location;
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
                new Rectangle(owningMenu.Position.X + Position.X, owningMenu.Position.Y + Position.Y, size.Width, size.Height);
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

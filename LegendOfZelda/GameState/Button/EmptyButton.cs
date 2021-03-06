﻿using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameState.Button
{
    internal class EmptyButton : IButton
    {
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private Rectangle size;
        private readonly IMenu owningMenu;

        public bool IsActive { get; private set; }

        private Point position;
        public Point Position { get => owningMenu.Position + position; set => position = new Point(value.X, value.Y); }

        public EmptyButton(IMenu owner, Rectangle location)
        {
            owningMenu = owner;
            Position = new Point(location.X, location.Y);
            SafeToDespawn = false;
            IsActive = true;
            size = location;
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

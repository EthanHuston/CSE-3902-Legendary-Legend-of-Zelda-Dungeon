using Microsoft.Xna.Framework;

namespace LegendOfZelda.Environment
{
    internal class RoomWall : IBlock
    {
        private Rectangle positionRectangle;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        public Point Position
        {
            get => new Point(positionRectangle.X, positionRectangle.Y);
            set
            {
                positionRectangle.X = value.X;
                positionRectangle.Y = value.Y;
            }
        }

        public RoomWall(Rectangle positionSize)
        {
            positionRectangle = positionSize;
        }
        
        public void Draw()
        {
            // does not need to draw
        }

        public Rectangle GetRectangle()
        {
            return positionRectangle;
        }
        
        public void Update()
        {
            // does not need to update
        }
    }
}

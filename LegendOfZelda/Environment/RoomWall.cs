using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Environment
{
    class RoomWall : IBlock
    {
        private Rectangle positionRectangle;
        private bool safeToDespawn;
        public Point Position { get; set; }

        public RoomWall(Rectangle positionSize)
        {
            positionRectangle = positionSize;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            // does not need to draw
        }

        public Rectangle GetRectangle()
        {
            return positionRectangle;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            // does not need to draw
        }
    }
}

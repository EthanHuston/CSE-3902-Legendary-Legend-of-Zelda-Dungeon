using LegendOfZelda.Environment;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Rooms
{
    internal class RoomChangeTrigger : IBlock
    {
        private Rectangle positionRectangle;
        private bool safeToDespawn;
        
        public Constants.Direction Side { get; private set; }
        public Point Position { get; set; }

        public RoomChangeTrigger(Constants.Direction side)
        {
            Side = side;
            switch (side)
            {
                case Constants.Direction.Right:
                    positionRectangle = RoomConstants.RoomChangeRightTrigger;
                    break;
                case Constants.Direction.Left:
                    positionRectangle = RoomConstants.RoomChangeLeftTrigger;
                    break;
                case Constants.Direction.Up:
                    positionRectangle = RoomConstants.RoomChangeUpTrigger;
                    break;
                case Constants.Direction.Down:
                    positionRectangle = RoomConstants.RoomChangeDownTrigger;
                    break;
            }
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
            // does not need to update
        }
    }
}

using Microsoft.Xna.Framework;

namespace LegendOfZelda.Rooms
{
    static class RoomUtilities
    {
        public static int GetDirectionalTextureAtlasRow(Constants.Direction side)
        {
            switch (side)
            {
                case Constants.Direction.Up:
                    return RoomConstants.UpDoorRow;
                case Constants.Direction.Left:
                    return RoomConstants.LeftDoorRow;
                case Constants.Direction.Right:
                    return RoomConstants.RightDoorRow;
                case Constants.Direction.Down:
                    return RoomConstants.DownDoorRow;
                default:
                    return 0;
            }
        }

        public static Constants.Direction GetDoorSide(Point position)
        {
            if ((position.X == RoomConstants.TopDoorX) && (position.Y == RoomConstants.TopDoorY))
                return Constants.Direction.Up;

            else if ((position.X == RoomConstants.LeftDoorX) && (position.Y == RoomConstants.LeftDoorY))
                return Constants.Direction.Left;

            else if ((position.X == RoomConstants.RightDoorX) && (position.Y == RoomConstants.RightDoorY))
                return Constants.Direction.Right;

            else if ((position.X == RoomConstants.BottomDoorX) && (position.Y == RoomConstants.BottomDoorY))
                return Constants.Direction.Down;

            return 0;
        }
    }
}

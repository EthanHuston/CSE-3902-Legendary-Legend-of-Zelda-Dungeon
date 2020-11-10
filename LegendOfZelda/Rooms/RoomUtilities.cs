using Microsoft.Xna.Framework;

namespace LegendOfZelda.Rooms
{
    static class RoomUtilities
    {
        public static int GetDoorTextureAtlasRow(Point position)
        {
            if ((position.X == RoomConstants.TopDoorX) && (position.Y == RoomConstants.TopDoorY))
                return RoomConstants.UpDoorRow;
            
            else if ((position.X == RoomConstants.LeftDoorX) && (position.Y == RoomConstants.LeftDoorY))
                return RoomConstants.LeftDoorRow;
            
            else if ((position.X == RoomConstants.RightDoorX) && (position.Y == RoomConstants.RightDoorY))
                return RoomConstants.RightDoorRow;
            
            else if ((position.X == RoomConstants.BottomDoorX) && (position.Y == RoomConstants.BottomDoorY))
                return RoomConstants.DownDoorRow;

            return 0;
        }
    }
}

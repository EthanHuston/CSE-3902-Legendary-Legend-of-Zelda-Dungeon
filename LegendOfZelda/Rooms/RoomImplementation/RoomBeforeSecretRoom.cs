using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    internal class RoomBeforeSecretRoom : RoomWithMovableSquare
    {
        public RoomBeforeSecretRoom(List<IPlayer> playerList, Game1 game) : base(playerList, game) { }

        public override IRoom GetRoom(Constants.Direction direction)
        {
            if (direction == Constants.Direction.Stairs) UpdatePlayerPositions();
            return base.GetRoom(direction);
        }

        private void UpdatePlayerPositions()
        {
            foreach (IPlayer player in AllObjects.PlayerList) player.Position = LinkConstants.SecretRoomEnterSpawnPosition;
        }
    }
}

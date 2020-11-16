using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomBeforeSecretRoom : RoomWithMovableSquare
    {
        public RoomBeforeSecretRoom(SpriteBatch spriteBatch, string fileName, List<IPlayer> playerList) : base(spriteBatch, fileName, playerList)
        {
        }

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

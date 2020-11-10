using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class OpenDoor : IDoor
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly ITextureAtlasSprite doorFloorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        private const int textureMapColumn = 0;
        private const int doorFloorTextureMapColumn = 6;
        private readonly int textureMapRow;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }
        public bool IsOpen { get; private set; }
        public Constants.Direction Side { get; private set; }
        public Room Location { get; private set; }

        public OpenDoor(SpriteBatch spriteBatch, Point spawnPosition, Room room)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            doorFloorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            safeToDespawn = false;
            Position = spawnPosition;
            IsOpen = true;
            Side = RoomUtilities.GetDoorSide(spawnPosition);
            textureMapRow = RoomUtilities.GetDirectionalTextureAtlasRow(Side);
            Location = room;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow), Constants.DrawLayer.OpenDoor);
            doorFloorSprite.Draw(sB, new Point(doorFloorTextureMapColumn, textureMapRow), Constants.DrawLayer.FloorTile);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, doorSprite.GetPositionRectangle().Width, doorSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            doorSprite.Update();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        void IDoor.OpenDoor()
        {
            // already open
        }
    }
}

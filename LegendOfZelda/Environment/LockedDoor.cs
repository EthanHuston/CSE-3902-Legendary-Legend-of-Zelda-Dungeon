using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class LockedDoor : IDoor
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        private int textureMapRow;
        private int textureMapColumn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public bool IsOpen { get; private set; }

        public LockedDoor(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
            IsOpen = false;
        }

        public void Draw()
        {
            textureMapRow = RoomUtilities.GetDirectionalTextureAtlasRow(Position);
            textureMapColumn = IsOpen ? RoomConstants.OpenDoorColumn : RoomConstants.LockedDoorColumn;
            float drawLayer = IsOpen ? Constants.DrawLayer.OpenDoor : Constants.DrawLayer.ClosedDoor;
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow), drawLayer);
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // put condition here for when door can be despawned
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, doorSprite.GetPositionRectangle().Width, doorSprite.GetPositionRectangle().Height);
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void OpenDoor()
        {
            IsOpen = true;
        }
    }
}

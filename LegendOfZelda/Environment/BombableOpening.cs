using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    internal class BombableOpening : IDoor
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public bool IsOpen { get; private set; }

        public BombableOpening(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
            IsOpen = false;
        }

        public void Draw()
        {
            int textureMapRow = RoomUtilities.GetDoorTextureAtlasRow(Position);
            int textureMapColumn = IsOpen ? RoomConstants.BombedDoorColumn : RoomConstants.BombableDoorColumn;
            float drawLayer = IsOpen ? Constants.DrawLayer.OpenDoor : Constants.DrawLayer.ClosedDoor;
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow), drawLayer);
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

        public void OpenDoor()
        {
            IsOpen = true;
        }
    }
}

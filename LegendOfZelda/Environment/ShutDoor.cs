using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class ShutDoor : IDoor
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        private int textureMapColumn;
        private int textureMapRow;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }
        public bool IsOpen { get; private set; }
        public Constants.Direction Side { get; private set; }
        public Room Location { get; private set; }

        public ShutDoor(SpriteBatch spriteBatch, Point position, Room room)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = position;
            safeToDespawn = false;
            IsOpen = false;
            Side = RoomUtilities.GetDoorSide(position);
            Location = room;
        }

        public void Draw()
        {
            int textureMapRow = RoomUtilities.GetDirectionalTextureAtlasRow(Side);
            textureMapColumn = IsOpen ? RoomConstants.OpenDoorColumn : RoomConstants.CrackedDoorColumn;
            float drawLayer = IsOpen ? Constants.DrawLayer.OpenDoor : Constants.DrawLayer.ClosedDoor;
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow), drawLayer);
        }

        public void Update()
        {
            doorSprite.Update();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public Rectangle GetRectangle()
        {
            return doorSprite.GetPositionRectangle();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void OpenDoor()
        {
            if (IsOpen) return;
            IsOpen = true;
            // also open door on other side of wall
            Location.GetRoom(Side).GetDoor(UtilityMethods.InvertDirection(Side)).OpenDoor();
            SoundFactory.Instance.CreateDoorUnlockSound().Play();
        }
    }
}

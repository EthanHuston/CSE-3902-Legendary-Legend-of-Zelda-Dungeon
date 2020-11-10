using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
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

        public ShutDoor(SpriteBatch spriteBatch, Point position)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = position;
            safeToDespawn = false;
            IsOpen = false;
        }

        public void Draw()
        {
            textureMapRow = RoomUtilities.GetDoorTextureAtlasRow(Position);
            textureMapColumn = IsOpen ? RoomConstants.OpenDoorColumn : RoomConstants.CrackedDoorColumn;
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
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
            IsOpen = true;
        }
    }
}

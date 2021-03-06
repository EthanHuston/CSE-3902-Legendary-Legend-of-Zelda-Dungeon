﻿using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class LockedDoor : IDoor
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly ITextureAtlasSprite doorFloorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private readonly int textureMapRow;
        private int textureMapColumn;
        private const int doorFloorTextureMapColumn = 5;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }
        public bool IsOpen { get; private set; }
        public Constants.Direction Side { get; private set; }
        public IRoom Location { get; private set; }

        public LockedDoor(SpriteBatch spriteBatch, Point spawnPosition, IRoom room)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            doorFloorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            SafeToDespawn = false;
            IsOpen = false;
            Side = RoomUtilities.GetDoorSide(spawnPosition);
            textureMapRow = RoomUtilities.GetDirectionalTextureAtlasRow(Side);
            Location = room;
        }

        public void Draw()
        {
            textureMapColumn = IsOpen ? RoomConstants.OpenDoorColumn : RoomConstants.LockedDoorColumn;
            float drawLayer = IsOpen ? Constants.DrawLayer.OpenDoor : Constants.DrawLayer.ClosedDoor;
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow), drawLayer);
            if (IsOpen) doorFloorSprite.Draw(sB, Position, new Point(doorFloorTextureMapColumn, textureMapRow), Constants.DrawLayer.FloorTile);
        }

        public void Update()
        {
            SafeToDespawn = !SafeToDespawn && false; // put condition here for when door can be despawned
        }
        
        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, doorSprite.GetPositionRectangle().Width, doorSprite.GetPositionRectangle().Height);
        }
        
        public void OpenDoor()
        {
            if (IsOpen) return;
            IsOpen = true;
            // also open door on other side of wall
            Location.GetRoom(Side).GetDoor(UtilityMethods.InvertDirection(Side)).OpenDoor();
            SoundFactory.Instance.CreateDoorUnlockSound().Play();
        }

        public void CloseDoor()
        {
            if (!IsOpen) return;
            IsOpen = false;
            // also open door on other side of wall
            Location.GetRoom(Side).GetDoor(UtilityMethods.InvertDirection(Side)).CloseDoor();
            SoundFactory.Instance.CreateDoorUnlockSound().Play();
        }
    }
}

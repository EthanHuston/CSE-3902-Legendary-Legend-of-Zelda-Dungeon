using LegendOfZelda.GameState;
using LegendOfZelda.GameState.ItemSelectionState;
using LegendOfZelda.GameState.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomMap : ISpawnable
    {
        private bool safeToDespawn;
        private readonly List<Room> roomsInMap;
        private readonly ITextureAtlasSprite roomIconSprite;
        private readonly SpriteBatch spriteBatch;
        private readonly Rectangle[] spriteSourceRectangles;
        private readonly Vector2 sourceRectangleSize;
        private Point mapGridSize => new Point(8, 8);

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public RoomMap(SpriteBatch spriteBatch, Rectangle[] spriteSourceRectangles, Vector2 sourceRectangleSize, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            roomsInMap = new List<Room>();
            roomIconSprite = GameStateSpriteFactory.Instance.CreateHudItemsSprite();
            Position = spawnPosition;
            this.spriteSourceRectangles = spriteSourceRectangles;
            this.sourceRectangleSize = new Vector2(sourceRectangleSize.X, sourceRectangleSize.Y);
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            foreach (Room room in roomsInMap)
            {
                Point drawLocation = new Point(
                    Position.X + (int)(room.LocationOnMap.X * sourceRectangleSize.X * Constants.GameScaler),
                    Position.Y + (int)((mapGridSize.Y - room.LocationOnMap.Y) * sourceRectangleSize.Y * Constants.GameScaler) - (int)(sourceRectangleSize.Y * Constants.GameScaler));
                
                roomIconSprite.Draw(spriteBatch, drawLocation, spriteSourceRectangles[room.RoomType]);
                if (room.Visiting) roomIconSprite.Draw(spriteBatch, drawLocation + ItemSelectionStateConstants.RoomMarkerDrawOffset, GameStateConstants.RoomMarkerTextureAtlasSource);
            }
        }

        public Rectangle GetRectangle()
        {
            return Rectangle.Empty;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            // no updates needed
        }

        public void AddRoomToMap(Room roomToAdd)
        {
            roomsInMap.Add(roomToAdd);
        }
    }
}

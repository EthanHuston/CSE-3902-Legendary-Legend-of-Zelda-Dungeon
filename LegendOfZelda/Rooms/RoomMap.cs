using LegendOfZelda.GameState;
using LegendOfZelda.GameState.ItemSelectionState;
using LegendOfZelda.GameState.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class RoomMap : IMenu
    {
        private readonly List<IRoom> roomsInMap;
        private readonly ITextureAtlasSprite roomIconSprite;
        private readonly SpriteBatch spriteBatch;
        private readonly Rectangle[] spriteSourceRectangles;
        private readonly Vector2 sourceRectangleSize;
        private Point MapGridSize => new Point(8, 8);

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public RoomMap(SpriteBatch spriteBatch, Rectangle[] spriteSourceRectangles, Vector2 sourceRectangleSize, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            roomsInMap = new List<IRoom>();
            roomIconSprite = GameStateSpriteFactory.Instance.CreateHudItemsSprite();
            Position = spawnPosition;
            this.spriteSourceRectangles = spriteSourceRectangles;
            this.sourceRectangleSize = new Vector2(sourceRectangleSize.X, sourceRectangleSize.Y);
        }

        public void Draw()
        {
            foreach (IRoom room in roomsInMap)
            {
                Point drawLocation = new Point(
                    Position.X + (int)(room.LocationOnMap.X * sourceRectangleSize.X * Constants.GameScaler),
                    Position.Y + (int)((MapGridSize.Y - room.LocationOnMap.Y) * sourceRectangleSize.Y * Constants.GameScaler) - (int)(sourceRectangleSize.Y * Constants.GameScaler));
                
                roomIconSprite.Draw(spriteBatch, drawLocation, spriteSourceRectangles[room.RoomType], Constants.DrawLayer.MapIcon);
                if (room.Visiting && room.LocationOnMap.X != -1) roomIconSprite.Draw(spriteBatch, drawLocation + ItemSelectionStateConstants.RoomMarkerDrawOffset, GameStateConstants.RoomMarkerTextureAtlasSource, Constants.DrawLayer.MapMarker);
            }
        }

        public Rectangle GetRectangle()
        {
            return Rectangle.Empty;
        }

        public void Update()
        {
            // no updates needed
        }

        public void AddRoomToMap(IRoom roomToAdd)
        {
            roomsInMap.Add(roomToAdd);
        }
    }
}

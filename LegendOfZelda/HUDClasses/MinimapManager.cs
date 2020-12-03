﻿using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.HUDClasses
{
    internal class MinimapManager
    {
        private readonly RoomGameState roomGameState;
        private readonly ISprite minimapSprite;
        private bool displayMinimap;
        private readonly ISprite linkMinimapSquare;
        private readonly ISprite triforceMinimapSquare;
        private Point triforceRoomLocation = new Point(5, 4);
        private bool hasCompass;
        private Point secretRoomLocation = new Point(-1, -1);

        public MinimapManager(RoomGameState roomGameState)
        {
            this.roomGameState = roomGameState;
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            linkMinimapSquare = HUDSpriteFactory.Instance.CreateLinkMinimapSquareSprite();
            triforceMinimapSquare = HUDSpriteFactory.Instance.CreateTriforceMinimapSquareSprite();
            displayMinimap = false;
            hasCompass = false;
        }

        public void Draw(Point hudPosition)
        {
            if (displayMinimap)
            {
                minimapSprite.Draw(roomGameState.Game.SpriteBatch, hudPosition + HUDConstants.MinimapLocation, Constants.DrawLayer.HUDMinimap);
                if (hasCompass)
                    triforceMinimapSquare.Draw(roomGameState.Game.SpriteBatch, hudPosition + HUDConstants.MinimapSquarePositions[triforceRoomLocation], Constants.DrawLayer.HUDMinimapItem);
                Point currentRoomLocation = roomGameState.CurrentRoom.LocationOnMap;
                if (!currentRoomLocation.Equals(secretRoomLocation))
                    linkMinimapSquare.Draw(roomGameState.Game.SpriteBatch, hudPosition + HUDConstants.MinimapSquarePositions[roomGameState.CurrentRoom.LocationOnMap], Constants.DrawLayer.HUDMinimapItem);
            }

        }

        public void Update()
        {
            if (!displayMinimap && roomGameState.PlayerList[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
            if (!hasCompass && roomGameState.PlayerList[0].GetQuantityInInventory(LinkConstants.ItemType.Compass) != 0)
                hasCompass = true;
            if (displayMinimap)
            {
                linkMinimapSquare.Update();
                triforceMinimapSquare.Update();
            }
        }
    }
}

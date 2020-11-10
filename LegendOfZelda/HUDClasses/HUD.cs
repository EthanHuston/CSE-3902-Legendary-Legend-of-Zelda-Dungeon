using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class HUD : IMenu
    {
        private readonly RoomGameState roomGameState;
        private readonly SpriteBatch spriteBatch;
        private readonly List<IPlayer> players;
        private readonly HeartManager heartManager;
        private readonly NumberManager numberManager;
        private readonly ISprite hudSprite;

        private readonly HUDNumber levelNum;
        private readonly ISprite minimapSprite;
        private bool displayMinimap;
        private readonly ISprite linkMinimapSquare;
        private readonly ISprite triforceMinimapSquare;
        private Point triforceRoomLocation = new Point(5, 4);
        private bool hasCompass;

        private readonly LinkConstants.ItemType primaryItem;
        private LinkConstants.ItemType secondaryItem;
        private readonly IButton primaryButton;
        private IButton secondaryButton;

        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionary;

        private bool safeToDespawn = false;

        private Point position;
        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public List<IButton> Buttons
        {
            get
            {
                List<IButton> list = new List<IButton>();
                return list;
            }
        }

        public HUD(RoomGameState gameState)
        {
            roomGameState = gameState;
            spriteBatch = gameState.Game.SpriteBatch;
            players = gameState.PlayerList;
            heartManager = new HeartManager((LinkPlayer)players[0]);
            numberManager = new NumberManager((LinkPlayer)players[0]);
            primaryItem = players[0].PrimaryItem;
            secondaryItem = players[0].SecondaryItem;
            FillSecondaryItemDictionary();
            primaryButton = new SwordInventoryButton(spriteBatch, this, HUDConstants.PrimaryItemLocation);
            secondaryButton = secondaryItemDictionary[secondaryItem];
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            linkMinimapSquare = HUDSpriteFactory.Instance.CreateLinkMinimapSquareSprite();
            triforceMinimapSquare = HUDSpriteFactory.Instance.CreateTriforceMinimapSquareSprite();
            levelNum = new HUDNumber(1);
            displayMinimap = false;
            hasCompass = false;
            Position = new Point(HUDConstants.hudx, HUDConstants.hudy);
        }

        public void Update()
        {
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Compass) != 0)
                hasCompass = true;
            if (players[0].SecondaryItem != secondaryItem)
                UpdateSecondaryItem();
            if (displayMinimap)
            {
                linkMinimapSquare.Update();
                triforceMinimapSquare.Update();
            }
            numberManager.Update();
            heartManager.Update();
        }

        private void UpdateSecondaryItem()
        {
            secondaryItem = players[0].SecondaryItem;
            secondaryButton = secondaryItemDictionary[secondaryItem];
        }

        public void Draw()
        {
            hudSprite.Draw(spriteBatch, position, Constants.DrawLayer.HUD);
            levelNum.Draw(spriteBatch, Position + HUDConstants.LevelNumberLocation, Constants.DrawLayer.MenuIcon);
            if (displayMinimap)
            {
                minimapSprite.Draw(spriteBatch, Position + HUDConstants.MinimapLocation, Constants.DrawLayer.Map);
                if (hasCompass)
                    triforceMinimapSquare.Draw(spriteBatch, position + HUDConstants.MinimapSquarePositions[triforceRoomLocation], Constants.DrawLayer.MapMarker);
                linkMinimapSquare.Draw(spriteBatch, position + HUDConstants.MinimapSquarePositions[roomGameState.CurrentRoom.LocationOnMap], Constants.DrawLayer.MapMarker);
            }
            foreach (IButton button in Buttons)
            {
                button.Draw();
            }
            primaryButton.Draw();
            secondaryButton.Draw();
            numberManager.Draw(spriteBatch, Position);
            heartManager.Draw(spriteBatch, Position);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public Rectangle GetRectangle()
        {
            return hudSprite.GetPositionRectangle();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        private void FillSecondaryItemDictionary()
        {
            secondaryItemDictionary = new Dictionary<LinkConstants.ItemType, IButton>
            {
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Bow, new ArrowWoodInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.None, GetEmptyButton() }
            };
        }

        private IButton GetEmptyButton()
        {
            return new EmptyButton(this, new Rectangle(HUDConstants.SecondaryItemLocation.X, HUDConstants.SecondaryItemLocation.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }
    }
}

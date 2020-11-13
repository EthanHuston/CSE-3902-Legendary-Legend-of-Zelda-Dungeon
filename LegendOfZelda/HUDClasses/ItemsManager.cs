using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class ItemsManager
    {
        private HUD hud;
        private SpriteBatch spriteBatch;
        private LinkConstants.ItemType primaryItem;
        private LinkConstants.ItemType secondaryItem;
        private IButton primaryButton;
        private IButton secondaryButton;

        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionary;

        public ItemsManager(HUD hud)
        {
            this.hud = hud;
            spriteBatch = hud.roomGameState.Game.SpriteBatch;
            primaryItem = hud.roomGameState.PlayerList[0].PrimaryItem;
            secondaryItem = hud.roomGameState.PlayerList[0].SecondaryItem;
            fillSecondaryItemDictionary();
            primaryButton = new SwordInventoryButton(hud.roomGameState.Game.SpriteBatch, hud, HUDConstants.PrimaryItemLocation);
            secondaryButton = secondaryItemDictionary[secondaryItem];
        }

        public void Draw(Point hudPosition)
        {
            primaryButton.Draw();
            secondaryButton.Draw();

        }

        public void Update()
        {
            if (hud.roomGameState.PlayerList[0].SecondaryItem != secondaryItem)
                UpdateSecondaryItem();
        }

        private void UpdateSecondaryItem()
        {
            secondaryItem = hud.roomGameState.PlayerList[0].SecondaryItem;
            secondaryButton = secondaryItemDictionary[secondaryItem];
        }

        public void fillSecondaryItemDictionary()
        {
            secondaryItemDictionary = new Dictionary<LinkConstants.ItemType, IButton>
            {
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Bow, new ArrowWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.None, GetEmptyButton() }
            };
        }

        private IButton GetEmptyButton()
        {
            return new EmptyButton(hud, new Rectangle(HUDConstants.SecondaryItemLocation.X, HUDConstants.SecondaryItemLocation.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }
    }
}

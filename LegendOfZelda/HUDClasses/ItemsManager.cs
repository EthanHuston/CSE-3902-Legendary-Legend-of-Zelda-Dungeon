using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Link;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class ItemsManager
    {
        private readonly HUD hud;
        private readonly SpriteBatch spriteBatch;
        private LinkConstants.ItemType secondaryItem;
        private readonly IButton primaryButton;
        private IButton secondaryButton;

        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionary;

        public ItemsManager(HUD hud)
        {
            this.hud = hud;
            spriteBatch = hud.roomGameState.Game.SpriteBatch;
            secondaryItem = hud.roomGameState.PlayerList[0].SecondaryItem;
            FillSecondaryItemDictionary();
            primaryButton = new SwordInventoryButton(hud.roomGameState.Game.SpriteBatch, hud, HUDConstants.PrimaryItemLocation);
            secondaryButton = secondaryItemDictionary[secondaryItem];
        }

        public void Draw()
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

        private void FillSecondaryItemDictionary()
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

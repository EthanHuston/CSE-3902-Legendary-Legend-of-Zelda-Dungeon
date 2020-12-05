using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class ItemsManagerSingleplayer
    {
        private readonly IMenu hud;
        private readonly IPlayer player;
        private readonly SpriteBatch spriteBatch;
        private readonly LinkConstants.ItemType primaryItem;
        private LinkConstants.ItemType secondaryItem;
        private readonly IButton primaryButton;
        private IButton secondaryButton;

        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionary;

        public ItemsManagerSingleplayer(HUD hud)
        {
            this.hud = hud;
            player = hud.roomGameState.GetPlayer(0);
            spriteBatch = hud.roomGameState.Game.SpriteBatch;
            primaryItem = player.PrimaryItem;
            secondaryItem = player.SecondaryItem;
            fillSecondaryItemDictionaries();
            primaryButton = new SwordInventoryButton(hud.roomGameState.Game.SpriteBatch, hud, HUDConstants.PrimaryItemLocation + HUDConstants.hudOffset);
            secondaryButton = secondaryItemDictionary[secondaryItem];
        }

        public void Draw()
        {
            primaryButton.Draw();
            secondaryButton.Draw();
        }

        public void Update()
        {
            if (player.SecondaryItem != secondaryItem)
                UpdateSecondaryItem();
        }

        private void UpdateSecondaryItem()
        {
            secondaryItem = player.SecondaryItem;
            secondaryButton = secondaryItemDictionary[secondaryItem];
        }

        public void fillSecondaryItemDictionaries()
        {
                secondaryItemDictionary = new Dictionary<LinkConstants.ItemType, IButton>
                {
                    { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation + HUDConstants.hudOffset)},
                    { LinkConstants.ItemType.Bomb, new BombInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation + HUDConstants.hudOffset)},
                    { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation + HUDConstants.hudOffset)},
                    { LinkConstants.ItemType.Bow, new ArrowWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation + HUDConstants.hudOffset)},
                    { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocation + HUDConstants.hudOffset)},
                    { LinkConstants.ItemType.None, GetEmptyButton() }
                };
        }

        private IButton GetEmptyButton()
        {
            return new EmptyButton(hud, new Rectangle(HUDConstants.SecondaryItemLocation.X, HUDConstants.SecondaryItemLocation.Y + HUDConstants.hudOffset.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }
    }
}

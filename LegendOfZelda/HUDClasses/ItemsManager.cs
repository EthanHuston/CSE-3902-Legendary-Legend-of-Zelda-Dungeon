using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class ItemsManager
    {
        private readonly IMenu hud;
        private IPlayer player;
        private readonly SpriteBatch spriteBatch;
        private readonly LinkConstants.ItemType primaryItem;
        private LinkConstants.ItemType secondaryItem;
        private readonly IButton primaryButton;
        private IButton secondaryButton;
        private int numPlayers;

        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionary;
        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionaryPlayer2;

        public ItemsManager(HUD hud, IPlayer player)
        {
            this.hud = hud;
            this.player = player;
            spriteBatch = hud.roomGameState.Game.SpriteBatch;
            primaryItem = player.PrimaryItem;
            secondaryItem = player.SecondaryItem;
            fillSecondaryItemDictionaries();
            primaryButton = new SwordInventoryButton(hud.roomGameState.Game.SpriteBatch, hud, HUDConstants.PrimaryItemLocation);
            secondaryButton = secondaryItemDictionary[secondaryItem];
            numPlayers = 1;
        }

        public ItemsManager(MultiplayerHUD hud, IPlayer player)
        {
            this.hud = hud;
            this.player = player;
            spriteBatch = hud.roomGameState.Game.SpriteBatch;
            primaryItem = player.PrimaryItem;
            secondaryItem = player.SecondaryItem;
            fillSecondaryItemDictionaries();
            primaryButton = new SwordInventoryButton(hud.roomGameState.Game.SpriteBatch, hud, HUDConstants.PrimaryItemLocation);
            secondaryButton = secondaryItemDictionary[secondaryItem];
            numPlayers = 2;
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
            if(numPlayers == 1)
                secondaryButton = secondaryItemDictionary[secondaryItem];
            else
                secondaryButton = secondaryItemDictionaryPlayer2[secondaryItem];
        }

        public void fillSecondaryItemDictionaries()
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

            secondaryItemDictionaryPlayer2 = new Dictionary<LinkConstants.ItemType, IButton>
            {
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocationPlayer2)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocationPlayer2)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocationPlayer2)},
                { LinkConstants.ItemType.Bow, new ArrowWoodInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocationPlayer2)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(spriteBatch, hud, HUDConstants.SecondaryItemLocationPlayer2)},
                { LinkConstants.ItemType.None, GetEmptyButton() }
            };
        }

        private IButton GetEmptyButton()
        {
            if(numPlayers == 1)
                return new EmptyButton(hud, new Rectangle(HUDConstants.SecondaryItemLocation.X, HUDConstants.SecondaryItemLocation.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));

            return new EmptyButton(hud, new Rectangle(HUDConstants.SecondaryItemLocationPlayer2.X, HUDConstants.SecondaryItemLocationPlayer2.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }
    }
}

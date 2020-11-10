using LegendOfZelda.GameState.Button;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class InventoryMenu : IMenu
    {
        private readonly IPlayer link;
        private readonly ISprite inventoryBackgroundSprite;
        private IButton secondaryItem;
        private bool safeToDespawn;
        private Dictionary<LinkConstants.ItemType, IButton> buttonsDict;
        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionary;


        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public List<IButton> Buttons
        {
            get
            {
                List<IButton> list = new List<IButton>();
                foreach (KeyValuePair<LinkConstants.ItemType, IButton> button in buttonsDict) list.Add(button.Value);
                return list;
            }
        }

        public InventoryMenu(IPlayer link)
        {
            inventoryBackgroundSprite = GameStateSpriteFactory.Instance.CreateInventoryBackgroundSprite();
            Position = ItemSelectionStateConstants.InventoryPaneStartPosition;
            this.link = link;
            secondaryItem = GetEmptyButton();
            InitButtonsDictionary();
            InitSecondaryItemDictionary();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            inventoryBackgroundSprite.Draw(link.Game.SpriteBatch, Position, Constants.DrawLayer.Menu);
            secondaryItem.Draw();
            foreach (KeyValuePair<LinkConstants.ItemType, IButton> button in buttonsDict)
            {
                if (button.Value.IsActive) button.Value.Draw();
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, inventoryBackgroundSprite.GetPositionRectangle().Width, inventoryBackgroundSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            inventoryBackgroundSprite.Update();
            secondaryItem = secondaryItemDictionary[link.SecondaryItem];
            foreach (KeyValuePair<LinkConstants.ItemType, IButton> item in buttonsDict)
            {
                if (link.GetQuantityInInventory(item.Key) > 0) item.Value.MakeActive();
                else item.Value.MakeInactive();
            }
        }

        private void InitButtonsDictionary()
        {
            buttonsDict = new Dictionary<LinkConstants.ItemType, IButton>
            {
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.BoomerangHudLocation)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.BombHudLocation)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.ArrowHudLocation)},
                { LinkConstants.ItemType.Bow, new BowInventoryButton(link.Game.SpriteBatch,this, ItemSelectionStateConstants.BowHudLocation)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.CandleHudLocation)}
            };
        }

        private void InitSecondaryItemDictionary()
        {
            secondaryItemDictionary = new Dictionary<LinkConstants.ItemType, IButton>
            {
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Bow, new ArrowWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.None, GetEmptyButton() }
            };
        }

        private IButton GetEmptyButton()
        {
            return new EmptyButton(this, new Rectangle(ItemSelectionStateConstants.SecondaryItemHudLocation.X, ItemSelectionStateConstants.SecondaryItemHudLocation.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }
    }
}

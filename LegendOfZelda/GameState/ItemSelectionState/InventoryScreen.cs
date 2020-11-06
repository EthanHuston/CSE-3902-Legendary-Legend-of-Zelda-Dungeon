using LegendOfZelda.GameState.Button;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class InventoryScreen : IMenu
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

        public InventoryScreen(IPlayer link)
        {
            inventoryBackgroundSprite = GameStateSpriteFactory.Instance.CreateInventoryBackgroundSprite();
            Position = Point.Zero;
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
            inventoryBackgroundSprite.Draw(link.Game.SpriteBatch, Position);
            secondaryItem.Draw();
            foreach (KeyValuePair<LinkConstants.ItemType, IButton> button in buttonsDict)
            {
                if (button.Value.IsActive) button.Value.Draw();
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, inventoryBackgroundSprite.GetPositionRectangle().Width, inventoryBackgroundSprite.GetPositionRectangle().Height);
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
                { LinkConstants.ItemType.Map, new MapInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.MapHudLocation)},
                { LinkConstants.ItemType.Compass, new CompassInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.CompassHudLocation)},
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.BoomerangHudLocation)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.BombHudLocation)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.ArrowHudLocation)},
                { LinkConstants.ItemType.Bow, new BowInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.BowHudLocation)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.CandleHudLocation)}
            };
        }

        private void InitSecondaryItemDictionary()
        {
            secondaryItemDictionary = new Dictionary<LinkConstants.ItemType, IButton>
            {
                { LinkConstants.ItemType.Map, new MapInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Compass, new CompassInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Bow, new ArrowWoodInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(link.Game.SpriteBatch, Position + GameStateConstants.SecondaryItemHudLocation)},
                { LinkConstants.ItemType.None, GetEmptyButton() }
            };
        }

        private IButton GetEmptyButton()
        {
            return new EmptyButton(new Rectangle(GameStateConstants.SecondaryItemHudLocation.X, GameStateConstants.SecondaryItemHudLocation.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }
    }
}

using LegendOfZelda.GameState.Button;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class InventoryScreen : IMenu
    {
        private readonly IPlayer link;
        private readonly ISprite itemSelectionBackgroundSprite;
        private bool safeToDespawn;
        private Dictionary<LinkConstants.ItemType, IButton> buttonsDict;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public List<IButton> Buttons { 
            get {
                List<IButton> list = new List<IButton>();
                foreach (KeyValuePair<LinkConstants.ItemType, IButton> button in buttonsDict) list.Add(button.Value);
                return list;
            }
        }

        public InventoryScreen(IPlayer link)
        {
            itemSelectionBackgroundSprite = GameStateSpriteFactory.Instance.CreateItemSelectionBackgroundSprite();
            Position = Point.Zero;
            this.link = link;
            InitButtonsList();
        }

        private void InitButtonsList()
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

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            itemSelectionBackgroundSprite.Draw(link.Game.SpriteBatch, Position);
            foreach(KeyValuePair<LinkConstants.ItemType, IButton> button in buttonsDict)
            {
                if (button.Value.IsActive) button.Value.Draw();
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, itemSelectionBackgroundSprite.GetPositionRectangle().Width, itemSelectionBackgroundSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            itemSelectionBackgroundSprite.Update();
            foreach (KeyValuePair<LinkConstants.ItemType, IButton> item in buttonsDict)
            {
                if (link.GetQuantityInInventory(item.Key) > 0) item.Value.MakeActive();
                else item.Value.MakeInactive();
            }
        }
    }
}

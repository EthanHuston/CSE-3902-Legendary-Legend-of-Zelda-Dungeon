using LegendOfZelda.GameState.Button;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class MapMenu : IMenu
    {
        private readonly IPlayer link;
        private readonly ISprite mapBackgroundSprite;
        private readonly RoomMap roomMap;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private Dictionary<LinkConstants.ItemType, IButton> buttonsDict;

        private Point position;
        public Point Position
        {
            get => new Point(position.X, position.Y);
            set
            {
                position = new Point(value.X, value.Y);
                roomMap.Position = Position + ItemSelectionStateConstants.MapPosition;
            }
        }

        public List<IButton> Buttons
        {
            get
            {
                List<IButton> list = new List<IButton>();
                foreach (KeyValuePair<LinkConstants.ItemType, IButton> button in buttonsDict) list.Add(button.Value);
                return list;
            }
        }

        public MapMenu(IPlayer link, RoomMap roomMap)
        {
            this.roomMap = roomMap;
            this.link = link;
            mapBackgroundSprite = GameStateSpriteFactory.Instance.CreateMapBackgroundSprite();
            Position = ItemSelectionStateConstants.MapPaneStartPosition;
            InitButtonsDictionary();
        }

        public void Despawn()
        {
            SafeToDespawn = true;
        }

        public void Draw()
        {
            mapBackgroundSprite.Draw(link.Game.SpriteBatch, Position, Constants.DrawLayer.Menu);
            foreach (KeyValuePair<LinkConstants.ItemType, IButton> button in buttonsDict)
            {
                if (button.Value.IsActive) button.Value.Draw();
            }
            roomMap.Draw();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, mapBackgroundSprite.GetPositionRectangle().Width, mapBackgroundSprite.GetPositionRectangle().Height);
        }

        

        public void Update()
        {
            mapBackgroundSprite.Update();
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
                { LinkConstants.ItemType.Map, new MapInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.MapHudLocation)},
                { LinkConstants.ItemType.Compass, new CompassInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.CompassHudLocation)}
            };
        }
    }
}

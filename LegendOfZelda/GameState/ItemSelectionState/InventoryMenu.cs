using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class InventoryMenu : IButtonMenu
    {
        private const int numRows = 2, numColumns = 5;
        private readonly List<Tuple<LinkConstants.ItemType, IButton, IButton>> itemButtonsTupleList; // <item type, button in inventory, button in selected item slot>
        private readonly IPlayer link;
        private readonly ISprite inventoryBackgroundSprite;
        private Tuple<LinkConstants.ItemType, IButton, IButton> secondaryItem;
        public ButtonSelector ButtonSelector { get; private set; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public List<IButton> Buttons { get; private set; }

        public InventoryMenu(IPlayer link)
        {
            inventoryBackgroundSprite = GameStateSpriteFactory.Instance.CreateInventoryBackgroundSprite();
            Position = ItemSelectionStateConstants.InventoryPaneStartPosition;
            this.link = link;
            itemButtonsTupleList = GetItemButtonsTupleList();
            Buttons = GetButtonsList(itemButtonsTupleList);
            ButtonSelector = new ButtonSelector(link.Game.SpriteBatch, this, Buttons, numRows, numColumns);
            secondaryItem = itemButtonsTupleList[itemButtonsTupleList.Count - 1];
        }

        private List<IButton> GetButtonsList(List<Tuple<LinkConstants.ItemType, IButton, IButton>> itemButtonTupleList)
        {
            List<IButton> list = new List<IButton>();
            foreach (var tuple in itemButtonTupleList)
                if (tuple.Item2 != null) list.Add(tuple.Item2);
            return list;
        }

        public void Draw()
        {
            inventoryBackgroundSprite.Draw(link.Game.SpriteBatch, Position, Constants.DrawLayer.Menu);
            secondaryItem.Item3.Draw();
            foreach (var button in itemButtonsTupleList)
            {
                if (button.Item2 != null && button.Item2.IsActive) button.Item2.Draw();
            }
            ButtonSelector.Draw();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, inventoryBackgroundSprite.GetPositionRectangle().Width, inventoryBackgroundSprite.GetPositionRectangle().Height);
        }

        public void Update()
        {
            inventoryBackgroundSprite.Update();
            ButtonSelector.Update();

            foreach (var tuple in itemButtonsTupleList)
            {
                if (tuple.Item2 == null) continue;
                if (link.GetQuantityInInventory(tuple.Item1) > 0) tuple.Item2.MakeActive();
                else tuple.Item2.MakeInactive();
            }
        }

        private List<Tuple<LinkConstants.ItemType, IButton, IButton>> GetItemButtonsTupleList()
        {
            return new List<Tuple<LinkConstants.ItemType, IButton, IButton>>
            {
                Tuple.Create(
                    LinkConstants.ItemType.Boomerang,
                    (IButton) new BoomerangWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.BoomerangHudLocation),
                    (IButton) new BoomerangWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)
                    ),

                Tuple.Create(
                    LinkConstants.ItemType.Bomb,
                    (IButton) new BombInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.BombHudLocation),
                    (IButton) new BombInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)
                    ),

                Tuple.Create(
                    LinkConstants.ItemType.Rupee,
                    (IButton) new ArrowWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.ArrowHudLocation),
                    (IButton) new ArrowWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)
                    ),

                Tuple.Create(
                    LinkConstants.ItemType.Bow,
                    (IButton) new BowInventoryButton(link.Game.SpriteBatch,this, ItemSelectionStateConstants.BowHudLocation),
                    (IButton) new ArrowWoodInventoryButton(link.Game.SpriteBatch, this, ItemSelectionStateConstants.SecondaryItemHudLocation)
                    ),

                Tuple.Create(
                    LinkConstants.ItemType.None,
                    (IButton) null,
                    GetEmptyButton()
                    )
            };
        }

        private IButton GetEmptyButton()
        {
            return new EmptyButton(this, new Rectangle(ItemSelectionStateConstants.SecondaryItemHudLocation.X, ItemSelectionStateConstants.SecondaryItemHudLocation.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }

        public void UpdateSecondaryItem(LinkConstants.ItemType item)
        {
            for (int i = 0; i < itemButtonsTupleList.Count; i++)
            {
                var tuple = itemButtonsTupleList[i];
                if (tuple.Item1 == item)
                {
                    ButtonSelector.SelectedCurrentIndex = i;
                    secondaryItem = tuple;
                    link.SecondaryItem = tuple.Item1;
                    return;
                }
            }
        }

        public void MoveSelection(Constants.Direction direction)
        {
            ButtonSelector.MoveSelector(direction);
            secondaryItem = itemButtonsTupleList[ButtonSelector.SelectedCurrentIndex];
            link.SecondaryItem = secondaryItem.Item1;
        }
    }
}

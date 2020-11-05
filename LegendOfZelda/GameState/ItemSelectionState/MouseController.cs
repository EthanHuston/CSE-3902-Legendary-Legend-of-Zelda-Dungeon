using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class MouseController : IController
    {
        private MouseState oldMouseState;
        private readonly List<IButton> buttons;
        private Dictionary<Type, ICommand> controllerMappings;

        public MouseController(IPlayer player, List<IButton> buttons)
        {
            oldMouseState = new MouseState();
            this.buttons = buttons;
            InitControllerMappings(player);
        }

        private void InitControllerMappings(IPlayer player)
        {
            controllerMappings = new Dictionary<Type, ICommand>
            {
                {typeof(ArrowWoodInventoryButton), new ChangeSecondaryToItem(player, Link.LinkConstants.ItemType.Bow) },
                {typeof(BombInventoryButton), new ChangeSecondaryToItem(player, Link.LinkConstants.ItemType.Bomb) },
                {typeof(BoomerangWoodInventoryButton), new ChangeSecondaryToItem(player, Link.LinkConstants.ItemType.Boomerang) },
                {typeof(BowInventoryButton), new ChangeSecondaryToItem(player, Link.LinkConstants.ItemType.Bow) },

            };
        }

        public GameStateConstants.InputType GetInputType()
        {
            return GameStateConstants.InputType.Mouse;
        }

        public OldInputState GetOldInputState()
        {
            return new OldInputState { oldMouseState = oldMouseState };
        }

        public void SetOldInputState(OldInputState oldInputState)
        {
            oldMouseState = oldInputState.oldMouseState;
        }

        public void Update()
        {
            MouseState newMouseState = Mouse.GetState();
            MouseState localOldMouseState = oldMouseState;
            oldMouseState = newMouseState;

            if (newMouseState.LeftButton == ButtonState.Pressed && localOldMouseState.LeftButton != ButtonState.Pressed)
            {
                Point mousePosition = newMouseState.Position;
                foreach (IButton button in buttons)
                {
                    Rectangle buttonRectangle = button.GetRectangle();
                    if (mousePosition.X > buttonRectangle.Left &&
                        mousePosition.X < buttonRectangle.Right &&
                        mousePosition.Y > buttonRectangle.Top &&
                        mousePosition.Y < buttonRectangle.Bottom)
                        controllerMappings[button.GetType()].Execute();
                }
            }

            oldMouseState = newMouseState;
        }
    }
}

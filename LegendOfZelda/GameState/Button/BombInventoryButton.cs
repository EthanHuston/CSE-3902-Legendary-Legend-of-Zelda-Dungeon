﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.GameState.Button
{
    class BombInventoryButton : IButton
    {
        private readonly ITextureAtlasSprite sprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;
        private readonly IMenu owningMenu;
        public bool IsActive { get; private set; }

        private Vector2 Size => GameStateConstants.StandardItemSpriteSize;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public BombInventoryButton(SpriteBatch spriteBatch, IMenu owner, Point relativePosition)
        {
            this.spriteBatch = spriteBatch;
            owningMenu = owner;
            Position = relativePosition;
            sprite = GameStateSpriteFactory.Instance.CreateHudItemsSprite();
            safeToDespawn = false;
            IsActive = true;
        }


        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, owningMenu.Position + Position, GameStateConstants.BombTextureAtlasSource, Constants.DrawLayer.MenuButton);
        }

        public Rectangle GetRectangle()
        {
            return !IsActive ?
                Rectangle.Empty :
                new Rectangle(Position.X, Position.Y, (int)(Size.X * Constants.GameScaler), (int)(Size.Y * Constants.GameScaler));
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            sprite.Update();
        }

        public void MakeActive()
        {
            IsActive = true;
        }

        public void MakeInactive()
        {
            IsActive = false;
        }
    }
}

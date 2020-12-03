using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Button
{
    internal class SwordInventoryButton : IButton
    {
        private readonly ITextureAtlasSprite sprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private readonly IMenu owningMenu;
        public bool IsActive { get; private set; }

        private Vector2 Size => GameStateConstants.StandardItemSpriteSize;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public SwordInventoryButton(SpriteBatch spriteBatch, IMenu owner, Point relativePosition)
        {
            this.spriteBatch = spriteBatch;
            owningMenu = owner;
            Position = relativePosition;
            sprite = GameStateSpriteFactory.Instance.CreateHudItemsSprite();
            SafeToDespawn = false;
            IsActive = false;
        }


        public void Despawn()
        {
            SafeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, owningMenu.Position + Position, GameStateConstants.SwordWoodTextureAtlasSource, Constants.DrawLayer.MenuButton);
        }

        public Rectangle GetRectangle()
        {
            return !IsActive ?
                Rectangle.Empty :
                new Rectangle(Position.X, Position.Y, (int)(Size.X * Constants.GameScaler), (int)(Size.Y * Constants.GameScaler));
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

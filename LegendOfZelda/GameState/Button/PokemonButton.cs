using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Button
{
    internal class PokemonButton : IOnOffButton
    {
        private ISprite sprite;
        private readonly ISprite buttonSelectedSprite;
        private readonly ISprite buttonSprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;
        public bool IsActive { get; private set; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        private bool isOn;
        public bool IsOn
        {
            get => isOn;
            set
            {
                isOn = value;
                sprite = isOn ? buttonSelectedSprite : buttonSprite;
            }
        }

        public PokemonButton(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            buttonSprite = GameStateSpriteFactory.Instance.CreatePokemonButtonSprite();
            buttonSelectedSprite = GameStateSpriteFactory.Instance.CreatePokemonButtonSelectedSprite();
            IsOn = false;

            Position = spawnPosition;
            safeToDespawn = false;
            IsActive = true;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, Position, Constants.DrawLayer.MenuButton);
        }

        public Rectangle GetRectangle()
        {
            return !IsActive ?
                Rectangle.Empty :
                new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
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

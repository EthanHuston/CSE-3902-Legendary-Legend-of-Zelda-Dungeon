using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameState.Sprite
{
    class RedOverlaySprite : ISprite
    {
        private Texture2D sprite;
        public RedOverlaySprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.RoomWidth), (int)(RoomConstants.RoomHeight));
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White * .5f, layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler));
        }
    }
}

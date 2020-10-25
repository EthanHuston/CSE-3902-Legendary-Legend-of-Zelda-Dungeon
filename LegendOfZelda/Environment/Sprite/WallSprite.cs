using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Environment.Sprite
{
    class WallSprite : ITextureAtlasSprite
    {
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public WallSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = sprite.Bounds;
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, Point.Zero);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation)
        {
            int width = sprite.Width;
            int height = sprite.Height / 4;
            destinationRectangle = new Rectangle(position.X, position.Y, RoomConstants.spriteMultiplier * width, RoomConstants.spriteMultiplier * height);
            Rectangle sourceRectangle = new Rectangle(width * textureLocation.X, height * textureLocation.Y, width, height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

        public void Update()
        {
            //No Update Required
        }
    }
}

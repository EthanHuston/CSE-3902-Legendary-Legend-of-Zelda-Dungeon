using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class NonMovingNonAnimatedSprite : ISprite
    {
        private Texture2D luigiStill;
        private SpriteBatch luigiStillSpriteBatch;
        //Animation code method taken from whitaker tutorials in Sprint0
        public NonMovingNonAnimatedSprite(ContentManager content)
        {
            luigiStill = content.Load<Texture2D>("Image/LuigiStill");
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            luigiStillSpriteBatch = spriteBatch;
            Rectangle destinationRectangle = new Rectangle(375, 200, 2 * luigiStill.Width, 2 * luigiStill.Width);
            Rectangle sourceRectangle = new Rectangle(0, 0, luigiStill.Width, luigiStill.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(luigiStill, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

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
    class NonMovingNonAnimatedTextSprite : ISprite
    {
        private SpriteFont font;
        private int score = 0;
        //Text sprite implementation taken from whitaker tutorials
        public NonMovingNonAnimatedTextSprite(ContentManager content)
        {
            font = content.Load<SpriteFont>("Text");
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Credits", new Vector2(50, 330), Color.Black);
            spriteBatch.DrawString(font, "Program Made By: Ethan Huston", new Vector2(50, 360), Color.Black);
            spriteBatch.DrawString(font, "Sprites from: http://www.mariouniverse.com/sprites-nes-smb/", new Vector2(50, 390), Color.Black);
            spriteBatch.End();

        }
    }
}

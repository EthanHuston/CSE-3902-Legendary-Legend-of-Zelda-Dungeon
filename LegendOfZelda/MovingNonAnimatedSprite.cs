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
    class MovingNonAnimatedSprite : ISprite
    {
        private Texture2D luigiDead;
        private SpriteBatch deadSpriteBatch;
        //Animation code method taken from whitaker tutorials in Sprint0
        private int currentYVal;
        private int maxYVal;
        private int minYVal;
        private bool currentDirection;

        public MovingNonAnimatedSprite(ContentManager content)
        {
            luigiDead = content.Load<Texture2D>("Image/LuigiDead");
            currentYVal = 200;
            minYVal = 200;
            maxYVal = 180;
            currentDirection = true;

        }

        public void Update()
        {
            if (currentDirection)
            {
                currentYVal--;
                if(currentYVal <= maxYVal)
                {
                    currentDirection = false;
                }
            }
            else
            {
                currentYVal++;
                if(currentYVal >= minYVal)
                {
                    currentDirection = true;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            deadSpriteBatch = spriteBatch;
            Rectangle sourceRectangle = new Rectangle(0, 0, luigiDead.Width, luigiDead.Height);
            Rectangle destinationRectangle = new Rectangle(375, currentYVal, 2* luigiDead.Width, 2 * luigiDead.Height);

            spriteBatch.Begin();
            spriteBatch.Draw(luigiDead, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}

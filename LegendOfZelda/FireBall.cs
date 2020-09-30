using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    class Fireball : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private int posX, posY, vx, vy;

        public Fireball(SpriteBatch spriteBatch, int posX, int posY, int vy)
        {
            this.spriteBatch = spriteBatch;
            this.sprite = SpriteFactory.Instance.CreateFireballSprite();
            this.posX = posX;
            this.posY = posY;
            this.vy = vy;
            this.vx = -5;
        }

        public void Update()
        {
            posX += vx;
            posY += vy;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, posX, posY);
        }
    }
}

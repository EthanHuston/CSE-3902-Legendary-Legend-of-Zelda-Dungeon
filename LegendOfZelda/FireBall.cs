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

        public Fireball(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.sprite = SpriteFactory.Instance.CreateFireballSprite();
        }

        public void Update()
        {
        }

        public void Draw()
        {
        }
    }
}

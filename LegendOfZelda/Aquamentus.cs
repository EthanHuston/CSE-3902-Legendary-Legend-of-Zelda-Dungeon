using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Aquamentus : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;

        public Aquamentus(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateAquamentusWalkingSprite();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
        }

        public void Draw()
        {
        }
    }
}

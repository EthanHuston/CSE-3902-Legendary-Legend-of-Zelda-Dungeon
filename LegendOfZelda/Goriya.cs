using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Goriya : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;

        public Goriya(SpriteBatch spriteBatch)
        {
            this.sprite = SpriteFactory.Instance.CreateDogLikeMonsterSprite();
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

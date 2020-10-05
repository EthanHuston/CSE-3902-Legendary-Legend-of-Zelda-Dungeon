using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Stairs : IInteractiveEnviornment
    {
        private StairSprite stairSprite;
        private SpriteBatch sB;
        public Stairs(SpriteBatch spriteBatch)
        {
            stairSprite = (StairSprite)SpriteFactory.Instance.CreateStairSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            stairSprite.Draw(sB, ConstantsSprint2.ieX, ConstantsSprint2.ieY);
        }

        public void Interaction()
        {

        }
        public void Update()
        {
        }
    }
}

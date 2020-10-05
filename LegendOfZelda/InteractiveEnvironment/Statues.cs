using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Statues : IInteractiveEnviornment
    {
        private StatueSprite statueSprite;
        private SpriteBatch sB;
        public Statues(SpriteBatch spriteBatch)
        {
            statueSprite = (StatueSprite)SpriteFactory.Instance.CreateStatueSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            statueSprite.Draw(sB, Sprint2.ieX, Sprint2.ieY);
        }

        public void Interaction()
        {
            
        }
    }
}

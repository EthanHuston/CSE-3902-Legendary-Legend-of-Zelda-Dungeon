using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class LadderTile : IInteractiveEnviornment
    {
        private LadderSprite ladderSprite;
        private SpriteBatch sB;
        public LadderTile(SpriteBatch spriteBatch)
        {
            ladderSprite = (LadderSprite)SpriteFactory.Instance.CreateLadderSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            ladderSprite.Draw(sB, Sprint2.ieX, Sprint2.ieY);
        }

        public void Interaction()
        {

        }
    }
}

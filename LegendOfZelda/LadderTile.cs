using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class LadderTile : IInteractiveEnviornment
    {
        private LadderSprite ladderSprite;
        private SpriteBatch sB;
        public LadderTile(SpriteBatch spriteBatch)
        {
            ladderSprite = (LadderSprite)SpriteFactory.Instance.CreateLadderSprite();
            sB = spriteBatch;
            ladderSprite.Draw(sB, Sprint2.itemX, Sprint2.itemY);
        }
        public void Interaction()
        {

        }
    }
}

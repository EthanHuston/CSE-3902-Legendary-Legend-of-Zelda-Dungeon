using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class GapTile : IInteractiveEnviornment
    {
        private TileBlackSprite tileBlackSprite;
        private SpriteBatch sB;
        public GapTile(SpriteBatch spriteBatch)
        {
            tileBlackSprite = (TileBlackSprite)SpriteFactory.Instance.CreateTileBlackSprite();
            sB = spriteBatch;
            tileBlackSprite.Draw(sB, Sprint2.ieX, Sprint2.ieY);
        }
        public void Interaction()
        {
            
        }
    }
}

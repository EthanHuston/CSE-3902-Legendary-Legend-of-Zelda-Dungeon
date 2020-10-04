using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Walls : IInteractiveEnviornment
    {
        private RoomBorderSprite roomBorderSprite;
        private SpriteBatch sB;
        int posX, posY;
        public Walls(SpriteBatch spriteBatch, int x, int y)
        {
            roomBorderSprite = (RoomBorderSprite)SpriteFactory.Instance.CreateRoomBorderSprite();
            sB = spriteBatch;
            roomBorderSprite.Draw(sB, Sprint2.ieX, Sprint2.ieY);
        }
        public void Interaction()
        {
            
        }
    }
}

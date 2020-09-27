using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class ShutDoor : IInteractiveEnviornment
    {
        private DoorSprite doorSprite;
        private SpriteBatch sB;
        public ShutDoor(SpriteBatch spriteBatch)
        {
            doorSprite = (DoorSprite)SpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            doorSprite.Draw(sB, Sprint2.itemX, Sprint2.itemY);
        }
        public void Interaction()
        {
            
        }
    }
}

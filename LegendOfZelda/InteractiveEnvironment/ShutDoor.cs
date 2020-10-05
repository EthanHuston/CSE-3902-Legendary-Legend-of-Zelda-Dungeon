using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class ShutDoor : IInteractiveEnviornment
    {
        private DoorSprite doorSprite;
        private SpriteBatch sB;
        public ShutDoor(SpriteBatch spriteBatch)
        {
            doorSprite = (DoorSprite)SpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, ConstantsSprint2.ieX, ConstantsSprint2.ieY, 1, 3);
        }

        public void Interaction()
        {
            
        }
        public void Update()
        {
        }
    }
}

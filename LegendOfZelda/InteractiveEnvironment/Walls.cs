using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Walls : IInteractiveEnviornment
    {
        private RoomBorderSprite roomBorderSprite;
        private SpriteBatch sB;
        public Walls(SpriteBatch spriteBatch, int x, int y)
        {
            roomBorderSprite = (RoomBorderSprite)SpriteFactory.Instance.CreateRoomBorderSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            roomBorderSprite.Draw(sB, ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY);
        }

        public void Interaction()
        {
            
        }
        public void Update()
        {
        }
    }
}

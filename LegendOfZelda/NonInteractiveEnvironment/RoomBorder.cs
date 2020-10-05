using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.NonInteractiveEnvironment
{
    class RoomBorder : INonInteractiveEnvironment
    {
        private RoomBorderSprite roomSprite;
        private SpriteBatch sb;
        int posX, posY;
        public RoomBorder(SpriteBatch spriteBatch, int x, int y)
        {
            roomSprite = (RoomBorderSprite)SpriteFactory.Instance.CreateRoomBorderSprite();
            sb = spriteBatch;
            posX = x;
            posY = y;
        }

        public void Draw()
        {
            roomSprite.Draw(sb, posX, posY);
        }
        public void Update()
        {
        }
    }
}

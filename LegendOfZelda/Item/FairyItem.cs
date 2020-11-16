using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Item
{
    internal class FairyItem : GenericItem
    {
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
        private Point position;
        public FairyItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateFairySprite(spawnPosition);
            itemType = LinkConstants.ItemType.Fairy;
            position = spawnPosition;
        }
        public override void Update()
        {
            movementBuffer++;
            CheckBounds();
            //Move based on current chosen direction for some time.
            if (xDir == 0 && yDir == 0)
            {
                position.X--;
                position.Y--;
            }
            else if (xDir == 0 && yDir == 1)
            {
                position.X--;
                position.Y++;
            }
            else if (xDir == 1 && yDir == 0)
            {
                position.X++;
                position.Y--;
            }
            else
            {
                position.X++;
                position.Y++;
            }

            if (movementBuffer > 10)
            {
                movementBuffer = 0;
                ChooseDirection();
            }
            sprite.Update();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = itemIsExpired && true;
        }
         private void CheckBounds()
        {
            if (position.X <= Constants.MinXPos + (Constants.GameScaler * RoomConstants.WallWidth))
            {
                position.X += 5;
            }
            else if (position.X >= Constants.MaxXPos - (Constants.GameScaler * RoomConstants.WallWidth))
            {
                position.X -= 5; ;
            }
            else if (position.Y <= Constants.MinYPos + (Constants.GameScaler * RoomConstants.WallWidth))
            {
                position.Y += 5; ;
            }
            else if (position.Y >= Constants.MaxYPos - (Constants.GameScaler * RoomConstants.WallWidth))
            {
                position.Y -= 5;
            }
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
    }
}

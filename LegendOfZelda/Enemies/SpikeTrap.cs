using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Enemies
{
    class SpikeTrap : INpc
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        private Point position = new Point(ConstantsSprint2.enemyNPCX, ConstantsSprint2.enemyNPCY);
        private int maxDistance = Constants.SpikeTrapMaxDist;
        private int currentDist = 0;
        private int goingVelocity = Constants.SpikeTrapGoingVelocity;
        private int returningVelocity = Constants.SpikeTrapReturningVelocity;
        bool returning = false;
        bool going = false;
        private IPlayer link;
        Rectangle LinkPosition;
        Rectangle TrapPosition;
        Constants.Direction currentDirection;

        public SpikeTrap(SpriteBatch spriteBatch, IPlayer link)
        {
            sprite = SpriteFactory.Instance.CreateSpikeTrapSprite();
            this.spriteBatch = spriteBatch;
            this.link = link;
        }

        public void Update()
        {
            sprite.Update();
            LinkPosition = link.GetRectangle();
            TrapPosition = sprite.GetPositionRectangle();
            if (!returning)
            {
                CheckOverlap();
            }
            else if(going)
            {
                if(currentDirection == Constants.Direction.Left)
                {
                    GoingLeft();
                } else if(currentDirection == Constants.Direction.Right)
                {
                    GoingRight();
                } else if(currentDirection == Constants.Direction.Up)
                {
                    GoingUp();
                }
                else
                {
                    GoingDown();
                }
            } else 
            {
                if (currentDirection == Constants.Direction.Left)
                {
                    ReturningRight();
                }
                else if (currentDirection == Constants.Direction.Right)
                {
                    ReturningLeft();
                }
                else if (currentDirection == Constants.Direction.Up)
                {
                    ReturningDown();
                }
                else
                {
                    ReturningUp();
                }
            }
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }
        private void CheckOverlap()
        {
            if((LinkPosition.Top <= TrapPosition.Bottom || LinkPosition.Bottom >= TrapPosition.Top) && LinkPosition.Left >= TrapPosition.Right)
            {
                currentDirection = Constants.Direction.Right;
                going = true;

            } else if((LinkPosition.Top <= TrapPosition.Bottom || LinkPosition.Bottom >= TrapPosition.Top) && LinkPosition.Right <= TrapPosition.Left)
            {
                currentDirection = Constants.Direction.Left;
                going = true;

            } else if(LinkPosition.Bottom <= TrapPosition.Top && (LinkPosition.Left <= TrapPosition.Right || LinkPosition.Right >= TrapPosition.Left))
            {
                currentDirection = Constants.Direction.Up;
                going = true;

            } else if(LinkPosition.Top >= TrapPosition.Bottom && (LinkPosition.Right <= TrapPosition.Left || LinkPosition.Left <= TrapPosition.Right))
            {
                currentDirection = Constants.Direction.Down;
                going = true;
            }
        }
        private void GoingRight()
        {
            position.X += goingVelocity;
            currentDist += goingVelocity;
            if(currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }
            
        }
        private void ReturningLeft()
        {
            position.X -= returningVelocity;
            currentDist -= returningVelocity;
            if(currentDist <= 0)
            {
                returning = false;
            }
        }
        private void ReturningRight()
        {
            position.X += returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
            {
                returning = false;
            }
        }
        private void ReturningUp()
        {
            position.Y -= returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
            {
                returning = false;
            }
        }
        private void ReturningDown()
        {
            position.Y += returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
            {
                returning = false;
            }
        }
        private void GoingLeft()
        {
            position.X -= goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }
        }
        private void GoingUp()
        {
            position.Y -= goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }
        }
        private void GoingDown()
        {
            position.Y += goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistance)
            {
                returning = true;
                going = false;
            }
        }
        public void ResetPosition()
        {
            position.X = ConstantsSprint2.enemyNPCX;
            position.Y = ConstantsSprint2.enemyNPCY;
        }
        public void Move(Vector2 distance)
        {

        }
        public void SetPosition(Point position)
        {
            this.position = position;
        }
        public bool SafeToDespawn()
        {
            return false;
        }
        public Point GetPosition()
        {
            return position;
        }
        public Rectangle GetRectangle()
        {
            //Not implemented yet.
            return sprite.GetPositionRectangle();
        }
    }
}

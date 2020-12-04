using LegendOfZelda.Enemies.Sprite;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies
{
    internal class SpikeTrap : INpc
    {
        private readonly IDamageableSprite sprite;
        private readonly SpawnSprite spawnSprite;
        private readonly SpriteBatch spriteBatch;
        private readonly int maxDistanceX = Constants.SpikeTrapMaxDistX;
        private readonly int maxDistanceY = Constants.SpikeTrapMaxDistY;
        private int currentDist = 0;
        private readonly int goingVelocity = Constants.SpikeTrapGoingVelocity;
        private readonly int returningVelocity = Constants.SpikeTrapReturningVelocity;
        private bool returning = false;
        private bool going = false;
        private readonly IPlayer link;
        private Rectangle LinkPosition;
        private Rectangle TrapPosition;
        private Constants.Direction currentDirection;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }
        private bool spawning;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public SpikeTrap(SpriteBatch spriteBatch, Point spawnPosition, IPlayer link)
        {
            sprite = EnemySpriteFactory.Instance.CreateSpikeTrapSprite();
            spawnSprite = (SpawnSprite)EnemySpriteFactory.Instance.CreateSpawnSprite();
            this.spriteBatch = spriteBatch;
            this.link = link;
            Position = spawnPosition;
            SafeToDespawn = false;
            spawning = true;
        }

        public void Update()
        {
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
            }
            else
            {
                sprite.Update();
                LinkPosition = link.GetRectangle();
                TrapPosition = GetRectangle();
                if (going)
                {
                    if (currentDirection == Constants.Direction.Left)
                    {
                        GoingLeft();
                    }
                    else if (currentDirection == Constants.Direction.Right)
                    {
                        GoingRight();
                    }
                    else if (currentDirection == Constants.Direction.Up)
                    {
                        GoingUp();
                    }
                    else
                    {
                        GoingDown();
                    }
                }
                else if (!returning)
                {
                    CheckOverlap();
                }
                else
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
        }

        public void ClockUpdate()
        {
            if (spawning)
            {
                spawnSprite.Update();
                spawning = !spawnSprite.AnimationDone();
            }
        }

        public void Draw()
        {
            if (spawning)
            {
                spawnSprite.Draw(spriteBatch, position, Constants.DrawLayer.EnemySpawnSprite);
            }
            else
            {
                sprite.Draw(spriteBatch, position, Constants.DrawLayer.Enemy);
            }
        }
        private void CheckOverlap()
        {
            if ((LinkPosition.Top <= TrapPosition.Bottom && LinkPosition.Bottom >= TrapPosition.Top) && (LinkPosition.Left >= TrapPosition.Right))
            {
                currentDirection = Constants.Direction.Right;
                going = true;

            }
            else if ((LinkPosition.Top <= TrapPosition.Bottom && LinkPosition.Bottom >= TrapPosition.Top) && (LinkPosition.Right <= TrapPosition.Left))
            {
                currentDirection = Constants.Direction.Left;
                going = true;

            }
            else if ((LinkPosition.Bottom <= TrapPosition.Top) && (LinkPosition.Left <= TrapPosition.Right && LinkPosition.Right >= TrapPosition.Left))
            {
                currentDirection = Constants.Direction.Up;
                going = true;

            }
            else if ((LinkPosition.Top >= TrapPosition.Bottom) && (LinkPosition.Right >= TrapPosition.Left && LinkPosition.Left <= TrapPosition.Right))
            {
                currentDirection = Constants.Direction.Down;
                going = true;
            }
        }
        private void GoingRight()
        {
            position.X += goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistanceX)
            {
                returning = true;
                going = false;
            }

        }
        private void ReturningLeft()
        {
            position.X -= returningVelocity;
            currentDist -= returningVelocity;
            if (currentDist <= 0)
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
            if (currentDist >= maxDistanceX)
            {
                returning = true;
                going = false;
            }
        }
        private void GoingUp()
        {
            position.Y -= goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistanceY)
            {
                returning = true;
                going = false;
            }
        }
        private void GoingDown()
        {
            position.Y += goingVelocity;
            currentDist += goingVelocity;
            if (currentDist >= maxDistanceY)
            {
                returning = true;
                going = false;
            }
        }
        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
        }
        
        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public void TakeDamage(double damage)
        {
            // spike trap is invincible
        }
        
        public void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection)
        {
            // cannot be knocketh backeth
        }

        public double GetDamageAmount()
        {
            return Constants.LinkEnemyCollisionDamage;
        }
        public void ResetSpawnCloud()
        {
            spawning = true;
        }
    }
}

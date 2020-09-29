using Microsoft.Xna.Framework;
using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.NotMoving;
using System;

namespace Sprint0.Link.State.Walking
{
    class LinkWalkingRightState : ILinkState
    {
        private Link link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkWalkingRightState(Link link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkWalkingRightState(Link link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingRightLinkSprite();
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            Vector2 position = link.GetPosition();
            position.X = position.X + Constants.LinkWalkDistanceIntervalPx;
            if (position.X >= Constants.MinXPos)
            {
                StopMoving();
                return;
            }
            link.SetPosition(position);

            link.CurrentSprite.Update();
        }

        public void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
        }

        public void MoveDown()
        {
            link.SetState(new LinkWalkingDownState(link, damaged, healthyDateTime));
        }

        public void MoveLeft()
        {
            link.SetState(new LinkWalkingLeftState(link, damaged, healthyDateTime));
        }

        public void MoveRight()
        {
            // Already moving right, do nothing
        }

        public void MoveUp()
        {
            link.SetState(new LinkWalkingUpState(link, damaged, healthyDateTime));
        }

        public void BeDamaged(int damage)
        {
            if (!damaged)
            {
                this.link.SubtractHealth(damage);
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
            }
        }

        public void BeHealthy()
        {
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillRightState(link, damaged, healthyDateTime));
        }

        public void SwordAttack()
        {
            link.SetState(new LinkAttackingRightState(link, damaged, healthyDateTime));
        }

        public void PickUpItem()
        {
            link.SetState(new LinkPickingUpItemState(link, damaged, healthyDateTime));
        }

        public void UseItem()
        {
            link.SetState(new LinkUsingItemUpState(link, damaged, healthyDateTime));
        }
    }
}

using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.State.Attacking
{
    class LinkAttackingUpState : ILinkState
    {
        private Link link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkAttackingUpState(Link link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkAttackingUpState(Link link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingUpLinkSprite();
            link.BlockStateChange = true;
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
            if (link.CurrentSprite.finishedAnimation())
            {
                link.BlockStateChange = false;
                StopMoving();
            }
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
            link.SetState(new LinkWalkingRightState(link, damaged, healthyDateTime));
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
        }

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillUpState(link, damaged, healthyDateTime));
        }

        public void SwordAttack()
        {
            // Already attacking, do nothing
        }

        public void PickUpItem()
        {
            link.SetState(new LinkPickingUpItemState(link, damaged, healthyDateTime));
        }

        public void UseItem()
        {
            link.SetState(new LinkUsingItemUpState(link, damaged, healthyDateTime));
        }

        public void PickUpSword()
        {
            link.SetState(new LinkPickingUpSwordState(link, damaged, healthyDateTime));
        }
    }
}

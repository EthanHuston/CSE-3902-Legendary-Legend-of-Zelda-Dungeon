using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkPickingUpTriforceState : ILinkState
    {
        private LinkPlayer link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkPickingUpTriforceState(LinkPlayer link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkPickingUpTriforceState(LinkPlayer link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(LinkPlayer link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpTriforceSprite();
        }

        public void Update()
        {
            if (link.CurrentSprite.FinishedAnimation())
            {
                link.BlockStateChange = false;
                StopMoving();
            }
            else
            {
                link.BlockStateChange = true;
            }
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
        }

        public void Draw()
        {
            float posX = link.GetPosition().X + Constants.LinkPickingUpTriforceSpawnOffsetX;
            float posY = link.GetPosition().Y + Constants.LinkPickingUpTriforceSpawnOffsetY;
            link.CurrentSprite.Draw(link.Game.SpriteBatch, new Vector2(posX, posY), damaged);
        }

        public void MoveDown()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveLeft()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveRight()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveUp()
        {
            // Cannot interupt state, do nothing
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
            link.SetState(new LinkStandingStillDownState(link, damaged, healthyDateTime));
        }

        public void UseSword()
        {
            // Cannot interupt state, do nothing
        }

        public void UseItem()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpSword()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpHeart()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpTriforce()
        {
            // Already picking up triforce, do nothing
        }

        public void PickUpBow()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBow()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpHeartContainer()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpBoomerang()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBomb()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBoomerang()
        {
            // Cannot interupt state, do nothing
        }

        public void UseSwordBeam()
        {
            // Cannot interupt state, do nothing
        }
    }
}

﻿using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State
{
    internal class LinkWalkingState : LinkGenericAbstractState
    {
        private int distanceWalked;
        private const int walkDistance = 16;
        private const int stepDistance = 1;

        public LinkWalkingState(LinkPlayer link, Constants.Direction direction, bool damaged, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
            spawnOffset = Point.Zero;
            link.FacingDirection = direction;
            InitClass();
        }

        protected override void InitClass()
        {
            distanceWalked = 0;

            switch (link.FacingDirection)
            {
                case Constants.Direction.Up:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingUpLinkSprite();
                    link.Velocity = new Vector2(0, -1 * stepDistance);
                    break;
                case Constants.Direction.Down:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingDownLinkSprite();
                    link.Velocity = new Vector2(0, stepDistance);
                    break;
                case Constants.Direction.Left:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingLeftLinkSprite();
                    link.Velocity = new Vector2(-1 * stepDistance, 0);
                    break;
                case Constants.Direction.Right:
                    link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingRightLinkSprite();
                    link.Velocity = new Vector2(stepDistance, 0);
                    break;
            }
        }

        protected override void UpdateState()
        {
            distanceWalked += (int)link.Velocity.Length();
            if (distanceWalked > walkDistance)
            {
                StopMoving();
            }
        }

        public override void Move(Constants.Direction direction)
        {
            // TODO: see what happens if we start moving from here
            // Link can only start moving from the LinkStandingStill state
        }
    }
}
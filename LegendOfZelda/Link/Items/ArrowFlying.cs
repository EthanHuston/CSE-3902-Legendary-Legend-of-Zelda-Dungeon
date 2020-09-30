using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Items
{
    class ArrowFlying : ILinkItem
    {
        private bool itemIsExpired;
        private Vector2 direction;
        private Vector2 position;
        private ILinkItemSprite sprite;
        private SpriteBatch spriteBatch;
        private const Constants.Items type = Constants.Items.Arrow;

        public ArrowFlying(Link link, Constants.Directions direction, Vector2 spawnLocation)
        {
            this.position = spawnLocation;
            this.spriteBatch = link.Game.SpriteBatch;
            position.X = link.GetPosition().X + Constants.ArrowSpawnXOffsetFromLink;
            position.Y = link.GetPosition().Y + Constants.ArrowSpawnYOffsetFromLink;
            switch (direction){
                case Constants.Directions.Down:
                    this.direction = new Vector2(0, 1);
                    sprite = LinkSpriteFactory.Instance.CreateArrowDownSprite();
                    break;
                case Constants.Directions.Up:
                    this.direction = new Vector2(0, -1);
                    sprite = LinkSpriteFactory.Instance.CreateArrowUpSprite();
                    break;
                case Constants.Directions.Right:
                    this.direction = new Vector2(1, 0);
                    sprite = LinkSpriteFactory.Instance.CreateArrowRightSprite();
                    break;
                case Constants.Directions.Left:
                    this.direction = new Vector2(1, 0);
                    sprite = LinkSpriteFactory.Instance.CreateArrowLeftSprite();
                    break;
            }
        }

        public void Update()
        {
            position.X += Constants.FlyingArrowDistanceIntervalPx * direction.X;
            position.Y += Constants.FlyingArrowDistanceIntervalPx * direction.Y;

            itemIsExpired = OutOfBounds(position); // or item hits enemy, but not yet implemented
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, direction);
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public Constants.Items GetItemType()
        {
            return type;
        }

        private bool OutOfBounds(Vector2 position)
        {
            return position.X > Constants.MaxXPos || position.X < Constants.MinXPos || position.Y > Constants.MaxYPos || position.Y < Constants.MinYPos;
        }
    }
}

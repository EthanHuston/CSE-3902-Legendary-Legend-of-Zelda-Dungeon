using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Item
{
    class BoomerangFlyingItem : ILinkItem
    {
        private bool itemIsExpired;
        private bool returningToLink;
        private Vector2 position;
        private ILinkItemSprite sprite;
        private SpriteBatch spriteBatch;
        private LinkPlayer link;
        private Constants.Direction direction;
        private const Constants.Item type = Constants.Item.Boomerang;

        public BoomerangFlyingItem(LinkPlayer link, Constants.Direction direction)
        {
            this.link = link;
            spriteBatch = link.Game.SpriteBatch;
            sprite = LinkSpriteFactory.Instance.CreateBoomerangFlyingSprite();
            position.X = link.GetPosition().X + Constants.BoomerangSpawnXOffsetFromLink;
            position.Y = link.GetPosition().Y + Constants.BoomerangSpawnYOffsetFromLink;
            this.direction = direction;
            returningToLink = false;
        }

        public void Update()
        {
            Vector2 linkPosition = link.GetPosition();
            MoveBoomerang();
            itemIsExpired = ReturnedToLink(linkPosition); // or item hits enemy, but not yet implemented
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, position);
        }

        public bool SafeToDespawn()
        {
            return itemIsExpired;
        }

        public Constants.Item GetItemType()
        {
            return type;
        }

        private bool ReturnedToLink(Vector2 linkPosition)
        {
            return position.X < linkPosition.X + Constants.BoomerangDespawnMaxXFromLink &&
            position.X > linkPosition.X + Constants.BoomerangDespawnMinXFromLink &&
            position.Y < linkPosition.Y + Constants.BoomerangDespawnMaxYFromLink &&
            position.Y > linkPosition.Y + Constants.BoomerangDespawnMinYFromLink;
        }

        private void MoveBoomerang()
        {
            returningToLink = GetDistanceFromLink() > Constants.BoomerangMaxDistanceFromLink;
            returningToLink = Utility.ItemIsOutOfBounds(position);
            switch (direction)
            {
                case Constants.Direction.Up:
                    position.X = link.GetPosition().X;
                    position.Y += Constants.ArrowFlyingDistanceInterval * (returningToLink ? 1 : -1);
                    break;
                case Constants.Direction.Down:
                    position.X = link.GetPosition().X;
                    position.Y += Constants.ArrowFlyingDistanceInterval * (returningToLink ? -1 : 1);
                    break;
                case Constants.Direction.Right:
                    position.X += Constants.ArrowFlyingDistanceInterval * (returningToLink ? -1 : 1);
                    position.Y = link.GetPosition().Y;
                    break;
                case Constants.Direction.Left:
                    position.X += Constants.ArrowFlyingDistanceInterval * (returningToLink ? 1 : -1);
                    position.Y = link.GetPosition().Y;
                    break;
            }
        }

        private double GetDistanceFromLink()
        {
            return Utility.GetDistance(position, link.GetPosition());
        }
    }
}

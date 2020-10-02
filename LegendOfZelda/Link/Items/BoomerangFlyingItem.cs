using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Items
{
    class BoomerangFlyingItem : ILinkItem
    {
        private bool itemIsExpired;
        private Vector2 direction;
        private Vector2 position;
        private ILinkItemSprite sprite;
        private SpriteBatch spriteBatch;
        private Link link;
        private const Constants.Item type = Constants.Item.Boomerang;

        public BoomerangFlyingItem(Link link, Constants.Direction direction)
        {
            this.link = link;
            this.spriteBatch = link.Game.SpriteBatch;
            position.X = link.GetPosition().X + Constants.BoomerangSpawnXOffsetFromLink;
            position.Y = link.GetPosition().Y + Constants.BoomerangSpawnYOffsetFromLink;
            // do something here with the direction - could we define a function to track it??
        }

        public void Update()
        {
            Vector2 linkPosition = link.GetPosition();
            // TODO: update position logic here - work in progress

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
            return position.X < linkPosition.X + Constants.BoomerangDespawnMaxXFromLink && position.X > linkPosition.X + Constants.BoomerangDespawnMinXFromLink && position.Y < linkPosition.Y + Constants.BoomerangDespawnMaxYFromLink && position.Y > linkPosition.Y + Constants.BoomerangDespawnMinYFromLink;
        }
    }
}

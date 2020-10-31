using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class BombItem : GenericItem
    {
        public BombItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateBombSprite();
            itemType = LinkConstants.ItemType.Bomb;
        }

        protected override void CheckItemIsExpired()
        {
            // put logic here if we want item to despawn after some time
            itemIsExpired = itemIsExpired && true;
        }
    }
}

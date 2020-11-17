using LegendOfZelda.Item.Sprite;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    internal class FairyItem : GenericItem
    {
        private readonly FairySprite fairySprite;
        public FairyItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateFairySprite(spawnPosition);
            fairySprite = (FairySprite)sprite;
            itemType = LinkConstants.ItemType.Fairy;
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = itemIsExpired && true;
        }

        public override void Update()
        {
            fairySprite.Update();
            Position = fairySprite.Position;
            sprite = fairySprite;
        }
    }
}

using LegendOfZelda.Item;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Item
{
    class BombExplodingItem : GenericProjectile
    {
        public BombExplodingItem(Game1 link, Point spawnPosition, Constants.ItemOwner owner) : base(link, spawnPosition, owner)
        {
            sprite = SpriteFactory.Instance.CreateBombExplodingSprite();
        }

        public override void Update()
        {
            sprite.Update();
        }

        protected override void CheckItemIsExpired()
        {
            sprite.FinishedAnimation();
        }

        public override Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }
    }
}

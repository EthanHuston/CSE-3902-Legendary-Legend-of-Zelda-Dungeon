namespace LegendOfZelda.Link.Interface
{
    internal interface ILinkState
    {
        void Update();
        void Draw();
        void Move(Constants.Direction direction);
        void BeDamaged(double damage);
        void BeHealthy(double healAmount);
        void StopMoving();
        void PickUpItem(LinkConstants.ItemType itemType);
        void UseSword();
    }
}

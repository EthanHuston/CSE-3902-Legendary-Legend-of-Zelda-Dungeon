using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Interface
{
    internal interface IPlayer : IDynamic
    {
        Game1 Game { get; }
        LinkConstants.ItemType PrimaryItem { get; }
        LinkConstants.ItemType SecondaryItem { get; set; }
        void BeHealthy(double healAmount);
        void BeDamaged(double damage);
        void IncreaseMaxHealth(int amount);
        void GiveFullHealth();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void PickupItem(LinkConstants.ItemType itemType);
        int GetQuantityInInventory(LinkConstants.ItemType itemType);
        void UsePrimary();
        void UseSecondary();
    }
}

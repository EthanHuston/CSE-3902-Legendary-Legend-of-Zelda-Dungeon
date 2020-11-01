using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Interface
{
    interface IPlayer : IDynamic
    {
        void BeHealthy(double healAmount);
        void BeDamaged(double damage);
        void IncreaseMaxHealth(int amount);
        void GiveFullHealth();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void UseSword();
        void UseBow();
        void PickupItem(LinkConstants.ItemType itemType);
        void UseBomb();
        void UseBoomerang();
        void UseSwordBeam();
    }
}

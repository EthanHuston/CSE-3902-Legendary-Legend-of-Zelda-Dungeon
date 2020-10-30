using LegendOfZelda.Interface;

namespace LegendOfZelda.Link
{
    interface IPlayer : IDynamic
    {
        void BeHealthy(double healAmount);
        void BeDamaged(double damage);
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
        void PickUpBoomerang();
        void UseSwordBeam();
    }
}

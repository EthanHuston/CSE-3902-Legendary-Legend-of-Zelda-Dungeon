using LegendOfZelda.Interface;

namespace LegendOfZelda.Link
{
    public interface IPlayer : IDynamic
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
        void PickUpSword();
        void PickUpHeartContainer();
        void PickUpBow();
        void PickUpTriforce();
        void PickupMap();
        void PickupBomb();
        void PickupKey();
        void PickupCompass();
        void PickupHeart();
        void PickupRupee();
        void PickupFairy();
        void PickupClock();
        void UseBomb();
        void UseBoomerang();
        void PickUpBoomerang();
        void UseSwordBeam();
    }
}

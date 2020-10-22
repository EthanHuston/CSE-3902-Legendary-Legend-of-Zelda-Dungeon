namespace LegendOfZelda.Interface
{
    public interface IPlayer : IDynamic
    {
        void BeHealthy(int healAmount);
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
        void Drag(ISpawnable dragger, int dragTime);
    }
}

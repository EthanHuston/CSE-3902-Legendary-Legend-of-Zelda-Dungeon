using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Interface
{
    interface ILinkState
    {
        void Update();
        void Draw();
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
        void BeDamaged(double damage);
        void BeHealthy(double healAmount);
        void StopMoving();
        void PickUpSword();
        void PickUpHeartContainer();
        void PickUpTriforce();
        void PickUpBow();
        void PickUpBoomerang();
        void UseBomb();
        void UseBoomerang();
        void UseSword();
        void UseBow();
        void UseSwordBeam();
        void Drag(ISpawnable drag, int dragTimeMs);
    }
}

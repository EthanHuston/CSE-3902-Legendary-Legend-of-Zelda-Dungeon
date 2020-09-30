namespace Sprint0.Link.Interface
{
    interface ILinkState
    {
        void Update();
        void Draw();
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
        void BeDamaged(int damage);
        void BeHealthy();
        void StopMoving();
        void SwordAttack();
        void ShootBow();
        void PickUpItem();
        void UseItem();
        void PickUpSword();
        void PickUpHeartContainer();
        void PickUpTriforce();
        void PickUpBow();
    }
}

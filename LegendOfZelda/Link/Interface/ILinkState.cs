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
        void PickUpItem();
        void UseItem();
        void PickUpSword();
        void PickUpHeart();
        void PickUpTriforce();
        void PickUpBow();
    }
}

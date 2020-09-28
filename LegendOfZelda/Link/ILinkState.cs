namespace Sprint0.Link
{
    interface ILinkState
    {
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
        void BeDamaged(int damage);
        void BeHealthy();
        void StopMoving();
        void Update();
        void SwordAttack();
        void PickUpItem();
        void UseItem();
    }
}

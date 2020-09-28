namespace Sprint0
{
    internal interface IPlayer
    {
        void Draw();
        void Update();
        void Heal(int healAmount);
        void TakeDamage(int damage);
        void SubtractHealth(int damage);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void SwordRight();
        void SwordLeft();
        void SwordDown();
        void SwordUp();
    }
}
namespace Sprint0
{
    internal interface IPlayer
    {
        void TakeDamage(int damage);
        void Heal(int healAmount);
        void Update();
        void Draw();
    }
}
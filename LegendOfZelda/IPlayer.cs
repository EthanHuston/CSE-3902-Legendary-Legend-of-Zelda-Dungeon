using Microsoft.Xna.Framework;

namespace Sprint0
{
    public interface IPlayer
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
        void SwordAttack();
        void ShootBow();
        Vector2 GetPosition();
        void PickUpSword();
        void PickUpHeartContainer();
        void PickUpBow();
        void PickUpTriforce();
        void UseBomb();
        void UseBoomerang();
    }
}
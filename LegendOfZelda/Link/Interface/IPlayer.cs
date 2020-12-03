using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Interface
{
    internal interface IPlayer : IDynamic
    {
        Game1 Game { get; }
        ILinkState State { get; }
        LinkConstants.ItemType PrimaryItem { get; }
        LinkConstants.ItemType SecondaryItem { get; set; }
        bool BeingDragged { get; set; }
        bool IsDead { get; }
        double MaxHealth { get; }
        double CurrentHealth { get; }
        int PlayerNumber { get; }
        void BeHealthy(double healAmount);
        void BeDamaged(double damage);
        void IncreaseMaxHealth(int amount);
        void GiveFullHealth();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void PickupItem(LinkConstants.ItemType itemType);
        void PickupTriforce();
        void UsePrimary();
        void UseSecondary();
        bool CanSpawnProjectile(LinkConstants.ProjectileType projectileType);
        void StartDeathAnimation();
        void ConsumeKey();
        void ForceMoveToPoint(Point position);
        int GetQuantityInInventory(LinkConstants.ItemType itemType);
    }
}

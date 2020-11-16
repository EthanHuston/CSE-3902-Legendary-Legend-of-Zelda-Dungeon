using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Enemies
{
    public interface INpc : ISpawnable
    {
        void TakeDamage(double damage);
        void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection);
        double GetDamageAmount();
        void Move(Vector2 correctDirection);
        void ResetSpawnCloud();
        void ClockUpdate();
    }
}

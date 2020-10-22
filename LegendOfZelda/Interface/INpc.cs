namespace LegendOfZelda.Interface
{
    public interface INpc : ISpawnable
    {
        void ResetPosition();
        void TakeDamage(double damage);
        void SetKnockBack(bool changeKnockback, Constants.Direction knockDirection);
        double GetDamageAmount();
    }
}

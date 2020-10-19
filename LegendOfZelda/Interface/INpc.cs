namespace LegendOfZelda.Interface
{
    public interface INpc : ISpawnable
    {
        void ResetPosition();
        void TakeDamage(double damage);
    }
}

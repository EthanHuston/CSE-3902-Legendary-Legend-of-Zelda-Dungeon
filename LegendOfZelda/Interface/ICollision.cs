namespace LegendOfZelda.Interface
{
    public interface ICollision<T, U>
    {
        void HandleCollision(T MainSpawnable, U SecondarySpawnable, Constants.Direction side);
    }
}

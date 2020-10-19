namespace LegendOfZelda.Interface
{
    public interface ICollision<T, U>
    {
        void HandleCollison(T MainSpawnable, U SecondarySpawnable, Constants.Direction side);
    }
}

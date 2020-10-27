namespace LegendOfZelda.GameLogic
{
    public interface ICollisionHandler<T, U>
    {
        void HandleCollision(T MainSpawnable, U SecondarySpawnable, Constants.Direction side);
    }
}

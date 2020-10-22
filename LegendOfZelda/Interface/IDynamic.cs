using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface IDynamic : ISpawnable
    {
        Vector2 GetVelocity();
        void Move(int distance, Vector2 velocity);
        void MoveOnce(Vector2 distance);
    }
}

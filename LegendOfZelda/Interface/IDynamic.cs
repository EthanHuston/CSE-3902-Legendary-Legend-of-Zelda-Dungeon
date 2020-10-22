using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface IDynamic : ISpawnable
    {
        
        Vector2 Velocity { get; }
        void Move(int distance, Vector2 velocity);
        void MoveOnce(Vector2 distance);
    }
}

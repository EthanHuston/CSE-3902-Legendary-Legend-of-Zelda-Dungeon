using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface IDynamic : ISpawnable
    {
        Vector2 Velocity { get; set; }
        void Move(int distance, Vector2 velocity);
    }
}

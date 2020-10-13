using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface IDynamic : ISpawnable
    {
        Vector2 GetVelocity();
    }
}

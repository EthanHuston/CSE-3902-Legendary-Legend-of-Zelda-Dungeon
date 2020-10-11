using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    interface IDynamic : ISpawnable
    {
        Vector2 GetVelocity();
    }
}

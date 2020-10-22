using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface ISpawnable
    {
        void Update();
        void Draw();
        void SetPosition(Point position);
        bool SafeToDespawn();
        Point GetPosition();
        Rectangle GetRectangle();
        void Despawn();
    }
}

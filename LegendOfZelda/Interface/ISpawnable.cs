using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface ISpawnable
    {
        void Update();
        void Draw();
        void Move(Vector2 distance);
        void SetPosition(Point position);
        bool SafeToDespawn();
        Point GetPosition();
        Rectangle GetRectangle();
    }
}

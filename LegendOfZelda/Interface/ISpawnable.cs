using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface ISpawnable
    {
        void Update();
        void Draw();
        void Move(int distance, Vector2 velocity);
        void SetPosition(Point position);
        bool SafeToDespawn();
        Point GetPosition();
        Rectangle GetRectangle();
        void Despawn();
    }
}

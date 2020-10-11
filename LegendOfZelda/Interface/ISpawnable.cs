using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    interface ISpawnable
    {
        void Update();
        void Draw();
        Rectangle GetRectangle();
        Vector2 GetPosition();
        void SetPosition(Vector2 position);
        void Move(Vector2 distance);
    }
}

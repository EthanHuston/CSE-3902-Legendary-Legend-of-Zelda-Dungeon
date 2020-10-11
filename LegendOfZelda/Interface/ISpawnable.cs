using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    interface ISpawnable
    {
        void Update();
        void Draw();
        void Move(Vector2 distance);
        void SetPosition(Vector2 position);
        Vector2 GetPosition();
        Rectangle GetRectangle();
    }
}

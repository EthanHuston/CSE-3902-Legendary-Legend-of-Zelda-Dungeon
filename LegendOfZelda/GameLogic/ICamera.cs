using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameLogic
{
    interface ICamera
    {
        bool IsPanning { get; }
        void Pan(Vector2 velocity, int distance);
        void Update();
        void Draw();
        void ReversePan();
    }
}

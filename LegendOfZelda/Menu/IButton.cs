using Microsoft.Xna.Framework;

namespace LegendOfZelda.Menu
{
    internal interface IButton
    {
        Point Position { get; set; }
        bool IsActive { get; }
        void MakeActive();
        void MakeInactive();
        void Update();
        void Draw();
        Rectangle GetRectangle();
    }
}

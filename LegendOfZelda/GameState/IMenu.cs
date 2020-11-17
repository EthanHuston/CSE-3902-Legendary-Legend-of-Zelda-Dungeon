using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameState
{
    internal interface IMenu
    {
        Point Position { get; set; }
        void Update();
        void Draw();
        Rectangle GetRectangle();
    }
}

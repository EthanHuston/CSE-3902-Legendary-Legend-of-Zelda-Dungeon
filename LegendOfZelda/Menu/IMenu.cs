using Microsoft.Xna.Framework;

namespace LegendOfZelda.Menu
{
    internal interface IMenu
    {
        Point Position { get; set; }
        void Update();
        void Draw();
        Rectangle GetRectangle();
    }
}

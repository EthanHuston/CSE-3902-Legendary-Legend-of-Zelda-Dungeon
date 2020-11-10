using Microsoft.VisualBasic.Logging;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface ISpawnable
    {
        Point Position { get; set; }
        void Update();
        void Draw();
        bool SafeToDespawn();
        Rectangle GetRectangle();
        void Despawn();
    }
}

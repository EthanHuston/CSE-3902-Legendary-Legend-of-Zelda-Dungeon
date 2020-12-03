using Microsoft.Xna.Framework;

namespace LegendOfZelda.Interface
{
    public interface ISpawnable
    {
        Point Position { get; set; }
        bool SafeToDespawn { get; set; }
        void Update();
        void Draw();
        Rectangle GetRectangle();
        void Despawn();
    }
}

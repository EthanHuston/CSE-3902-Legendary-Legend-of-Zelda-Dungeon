namespace LegendOfZelda.Interface
{
    public interface INpc : ISpawnable
    {
        void Update();

        void Draw();

        void ResetPosition();
    }
}

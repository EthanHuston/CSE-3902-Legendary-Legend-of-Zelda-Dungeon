namespace LegendOfZelda.Link.Interface
{
    interface ISpawnedItems
    {
        void UpdateAll();
        void DrawAll();
        void SpawnNewSpawnable(ISpawnable spawnable);
    }
}

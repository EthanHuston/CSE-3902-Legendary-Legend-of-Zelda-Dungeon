namespace LegendOfZelda.Link.Interface
{
    interface ISpawnedItems
    {
        void UpdateAll();
        void DrawAll();
        bool SpawnNewItem(ILinkItem item);
    }
}
